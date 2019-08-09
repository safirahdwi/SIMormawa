using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using IPB.Ldap;
using System.Security.Authentication;
using System.Threading.Tasks;
using Ormawa.BusinessModel;
using AuthenticationException = Ormawa.BusinessModel.AuthenticationException;
using Ormawa.ViewModels;
using System.Linq;
using Newtonsoft.Json;

namespace Ormawa.Controllers
{
    public class AccountController : AbstractBaseController
    {
        private readonly AccountModel _accountModel;

        public AccountController(AccountModel accountModel)
        {
            _accountModel = accountModel;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new ViewModels.LoginViewModel {ReturnUrl = returnUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(ViewModels.LoginViewModel login, string returnurl)

        {
            LdapUser user;
            try
            {
                user = await _accountModel.Authenticate(login.Username, login.Password);
            }
            catch (AuthenticationException e)
            {
                SetErrorNotification("Login gagal. " + e.ErrorMessage);
                return View(login);
            }

            if (user != null)
            {
                return await ProccessLogin(user.Nip, user.Nim, user.TipeAkun.ToString(), login, returnurl, user);
            }
            else
            {
                return Redirect(login.ReturnUrl);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        private async Task<ActionResult> ProccessLogin(string Nip, string Nim, string TipeAkun, LoginViewModel model, string returnUrl, LdapUser user)
        {
            TipeAkun = TipeAkun != null ? TipeAkun.ToLower() : TipeAkun;
            if (TipeAkun == "student")
            {
                var roleMahasiswa = _accountModel.LoginMahasiswa(Nim, model.Username);
                var ormawa = _accountModel.GetNamaOrganisasi(int.Parse(roleMahasiswa.FirstOrDefault().MahasiswaID));
                if (roleMahasiswa == null || roleMahasiswa.Count == 0)
                {
                    SetErrorNotification("Anda tidak memiliki akses ID IPB ke sistem ini");
                    return View(model);
                }
                if (roleMahasiswa.Count == 1)
                {
                    var role = roleMahasiswa.First();
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, role.OrangID.ToString()),
                        new Claim(ClaimTypes.Email, model.Username.ToString()),
                        new Claim(ClaimTypes.Name, role.Nama.ToString()),
                        new Claim(ClaimTypes.Role, role.JenisPengguna.ToString()),
                        new Claim(ClaimTypes.Actor, role.MahasiswaID.ToString()),
                        new Claim(ClaimTypes.GroupSid, role.StrukturOrganisasiID.ToString()),
                        new Claim(ClaimTypes.PrimaryGroupSid, role.StrukturOrganisasi.ToString()),
                        new Claim(ClaimTypes.Sid, ormawa.Id.ToString()),
                        new Claim(ClaimTypes.Country, ormawa.OrganisasiOrmawa.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var props = new AuthenticationProperties { IsPersistent = model.RememberMe };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
                    if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")

                        return RedirectToAction("Index", "Dashboards");
                    else
                        return Redirect(returnUrl);
                }
                else
                {
                    SetSuccessNotification("Berhasil Login");
                    TempData["roles"] = JsonConvert.SerializeObject(roleMahasiswa);
                    return RedirectToAction("Role", new { returnurl = returnUrl });
                }
            }
            //else
            //{
            //    if (TipeAkun != "dosen" && TipeAkun != "tendik")
            //    {
            //        SetErrorNotification("Terjadi Kesalahan");
            //        return View(model);
            //    }
            //    var rolePegawai = _accountModel.LoginPegawai(Nip, model.Username);
            //    if (rolePegawai == null || rolePegawai.Count == 0)
            //    {
            //        SetErrorNotification("Anda tidak memiliki akses ID IPB ke sistem ini");
            //        return View(model);
            //    }
            //    if (rolePegawai.Count == 1)
            //    {
            //        var role = rolePegawai.First();

            //        if (_accountModel.HasPengguna(Convert.ToInt32(role.PegawaiID)))
            //            _accountModel.SaveRiwayatKunjungan(_accountModel.GetPengguna(Convert.ToInt32(role.PegawaiID)).Id);

            //        var claims = new List<Claim>
            //        {
            //            new Claim(ClaimTypes.NameIdentifier, role.PegawaiID.ToString()),
            //            new Claim(ClaimTypes.Email, model.Username.ToString()),
            //            new Claim(ClaimTypes.Name, role.Nama.ToString()),
            //            new Claim(ClaimTypes.Role, role.JenisPengguna.ToString()),
            //            new Claim(ClaimTypes.Actor, role.PegawaiID.ToString()),
            //            new Claim(ClaimTypes.GroupSid, role.StrukturOrganisasiID.ToString()),
            //            new Claim(ClaimTypes.PrimaryGroupSid, role.StrukturOrganisasi.ToString())
            //        };

            //        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //        var principal = new ClaimsPrincipal(identity);

            //        var props = new AuthenticationProperties { IsPersistent = model.RememberMe };
            //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
            //        if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")

            //            return RedirectToAction("Index", "Dashboard", new { Area = "Beranda" });
            //        else
            //            return Redirect(returnUrl);
            //    }
            //    else
            //    {
            //        TempData["roles"] = JsonConvert.SerializeObject(rolePegawai);
            //        return RedirectToAction("Role", new { returnurl = returnUrl });
            //    }
            //}
            return View();
        }

    }
}
