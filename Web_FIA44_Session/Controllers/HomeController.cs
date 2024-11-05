using Microsoft.AspNetCore.Mvc;

namespace Web_FIA44_Session.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			//Session auslesen wenn vorhanden oder "Leere Session" wenn nicht! ?? bedeutet, dass wenn der linke Wert null ist, der rechte Wert genommen wird
			//dies ist eine Kurzschreibweise für eine if-Abfrage  ein tenärer Ausdruck
			string SessionInhalt = HttpContext.Session.GetString("SessionKey") ?? "Leere Session";
			//ViewBag ist ein dynamisches Objekt, das dazu verwendet wird, Daten zwischen Controller und View zu übergeben
			ViewBag.SessionInhalt = SessionInhalt;
			return View();
		}
		public IActionResult SetSession(string Eingabe)
		{
			//Session setzen
			HttpContext.Session.SetString("SessionKey", Eingabe);
			//Redirect auf Index
			return RedirectToAction("Index");
		}
		public IActionResult deleteSession()
		{
			//clear() löscht alle Einträge aus der Session
			HttpContext.Session.Clear();
			//oder nur einen bestimmten Eintrag löschen
			//HttpContext.Session.Remove("SessionKey");
			return View();
		}
	}

}
