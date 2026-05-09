using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Sockets;

namespace EC2SampleUI.Pages
{
    public class IndexModel : PageModel
    {
        public string IpAddress { get; set; }
        public string HostName { get; set; }
        public void OnGet()
        {
            HostName = System.Net.Dns.GetHostName();
            IPHostEntry hostEntry = Dns.GetHostEntry(HostName);
            IpAddress = hostEntry.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork)?.ToString() ?? string.Empty;
        }
    }
}
