using EDIMonitorDemoData.Models;

namespace EDIMonitorDemoData.Repositories.Interfaces
{
    public interface IKonturOrderRepository
    {
        KonturOrder[] Items { get; set; }

        KonturOrder[] LoadArchive();
        KonturOrder[] LoadFromCH();
        KonturOrder[] LoadInbox();
        KonturOrder[] LoadInboxTest();
        KonturOrder[] LoadToCH();
    }
}