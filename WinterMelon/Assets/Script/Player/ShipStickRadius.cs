using UnityEngine;

public class ShipStickRadius : MonoBehaviour {
    public Transform m_ScrapHolder;

    public bool HasScrap() {
        return m_ScrapHolder.childCount > 0;
    }

    public int SellScrap() {
        int totalProfit = 0;

        foreach (Transform scrap in m_ScrapHolder) {
            totalProfit += scrap.GetComponent<BaseScrap>().m_SellValue;
        }

        // Delete all scrap
        for (int i = m_ScrapHolder.childCount - 1; i >= 0; i--) {
            Destroy(m_ScrapHolder.GetChild(i).gameObject);
        }

        return totalProfit;
    }
}
