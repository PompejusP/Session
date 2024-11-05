namespace Web_FIA44_Session
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllersWithViews();
			//Unterstützung für Sessions hinzufügen(bzw. Aktivieren)
			builder.Services.AddSession(options =>
			{
				//hier können weitere Optionen gesetzt werden
				//IdleTimeout = TimeSpan.FromMinutes(30) bedeutet, dass die Session nach 30 Minuten Inaktivität abläuft und gelöscht wird
				options.IdleTimeout = TimeSpan.FromMinutes(10);
				// HttpOnly = true bedeutet, dass das Cookie nur über HTTP(S) erreichbar ist
				options.Cookie.HttpOnly = true;
				// Cookie-Einstellungen (lege ein sicheres Cookie an)
				//IsEssential = true bedeutet, dass das Cookie immer gesendet wird, also nur die Cookies die für die Funktionalität der Seite notwendig sind
				options.Cookie.IsEssential = true;
				//Name = "SessionCookie" bedeutet, dass das Cookie den Namen "SessionCookie" hat
				options.Cookie.Name = "SessionCookie";
			});

			var app = builder.Build();

			app.MapControllerRoute(name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.UseStaticFiles();
			app.UseSession();

			app.UseRouting();
			app.Run();
		}
	}
}
