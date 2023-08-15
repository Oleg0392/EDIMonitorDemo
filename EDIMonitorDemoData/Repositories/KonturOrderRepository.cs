using System.IO;
using System.Xml;
using EDIMonitorDemoData.Models;
using EDIMonitorDemoData.Repositories.Interfaces;

namespace EDIMonitorDemoData.Repositories
{
    public class KonturOrderRepository : IKonturOrderRepository
    {
        public KonturOrder[] Items { get; set; }

        private string InboxPath { get; set; } = @"\\EDI-MGN\zakaz\EXPIMP\Loading\SKBKontur\Inbox\";
        private string ArchivePath { get; set; } = @"\\EDI-MGN\zakaz\EXPIMP\Loading\Archive\SKBKontur\";
        private string FromCHPath { get; set; } = @"\\EDI-MGN\zakaz\EXPIMP\InOut\SKBKontur\fromCH\";
        private string ToCHPath { get; set; } = @"\\EDI-MGN\zakaz\EXPIMP\InOut\SKBKontur\toCH\";

        public KonturOrderRepository()
        {
            Items = Array.Empty<KonturOrder>();
        }

        public KonturOrder[] LoadInbox()
        {
            LoadKonturOrders(InboxPath);
            return Items;
        }

        public KonturOrder[] LoadArchive()
        {
            LoadKonturOrders(ArchivePath);
            return Items;
        }

        public KonturOrder[] LoadFromCH()
        {
            LoadKonturOrders(FromCHPath);
            return Items;
        }

        public KonturOrder[] LoadToCH()
        {
            LoadKonturOrders(ToCHPath);
            return Items;
        }

        private void LoadKonturOrders(string ordersPath)
        {
            string[] files = Directory.GetFiles(ordersPath, "ORDERS*.xml");
            if (files != null)
            {
                if (files.Length > 0)
                {
                    Items = new KonturOrder[files.Length];
                    for (int i = 0; i < files.Length; i++)
                    {
                        XmlDocument document = new XmlDocument();
                        document.Load(files[i]);
                        try
                        {
                            var nodeList = document.SelectSingleNode("/eDIMessage/order/buyer").ChildNodes;
                            string buyerName = String.Empty;
                            foreach (XmlNode node in nodeList)
                            {
                                if (node.Name == "selfEmployed")
                                {
                                    buyerName = node.SelectSingleNode("//fullName/lastName").InnerText;
                                    buyerName += " " + node.SelectSingleNode("//fullName/firstName").InnerText;
                                    buyerName += " " + node.SelectSingleNode("//fullName/middleName").InnerText;
                                    break;
                                }
                            }
                            if (String.IsNullOrEmpty(buyerName)) buyerName = document.SelectSingleNode("/eDIMessage/order/buyer/organization/name").InnerText;
                            Items[i] = new KonturOrder
                            {
                                Number = document.SelectSingleNode("/eDIMessage/order").Attributes["number"].Value,
                                OrderDate = Convert.ToDateTime(document.SelectSingleNode("/eDIMessage/order").Attributes["date"].Value),
                                RevisionNumber = Convert.ToInt32(document.SelectSingleNode("/eDIMessage/order").Attributes["revisionNumber"].Value),
                                BuyerName = buyerName
                            };
                        }
                        catch (Exception excp)
                        {

                        }
                    }
                }
            }
        }
    }
}
