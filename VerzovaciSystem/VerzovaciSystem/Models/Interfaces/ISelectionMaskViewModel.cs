using VerzovaciSystem.Models.Entities;

namespace VerzovaciSystem.Models.Interfaces
{
    public interface ISelectionMaskViewModel
    {
        //pro zobrazení vyhledávací masky
        void GetSelectionMask();

        // najde dnešní verze po startu aplikace nebo odkazem v Layotu dle TRUNC(VER_DATETIME) <= TRUNC(SYSDATE)  
        void GetTodayVersions();

        // Vrátí odpovídající záznamy dle vyhledávací masky vybrané z DB View V_VERSION_LIST1
        void GetSelectedRecords(SelectionMaskEntity selectionsparameters);
    }
}
