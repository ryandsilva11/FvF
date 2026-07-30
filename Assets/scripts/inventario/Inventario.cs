using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Inventario : MonoBehaviour
{
    //variáveis públicas
    public GameObject inventario;
    public GameObject mainPlayer;
    public Slot[] slots;
    public TextMeshProUGUI descricao;
    public GameObject painelInventario;
    public static bool IsActive;

    //variáveis privadas
    private int slotSelec = -1;

    private void Start()
    {
        Time.timeScale = 1.0f;
        inventario.SetActive(false);
        IsActive = false;
        descricao.text = "Nao ha nenhum item aqui";
        DesativarSelecaoSlots();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AlternarInventario();
        }

        if (painelInventario.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("SelecaoFases");
        }
    }

    public void AlternarInventario()
    {
        if (IsActive)
            FecharInventario();
        else
            AbrirInventario();
    }

    public void AbrirInventario()
    {
        IsActive = true;
        inventario.SetActive(true);
        slotSelec = -1; // Nenhum slot selecionado ao abrir
        descricao.text = "Nao ha nenhum item aqui";
        DesativarSelecaoSlots();
        Time.timeScale = 0.0f;
        mainPlayer.GetComponent<MainPlayer>().enabled = false;
    }

    public void FecharInventario()
    {
        IsActive = false;
        inventario.SetActive(false);
        slotSelec = -1; // Resetar seleção
        descricao.text = "Nao ha nenhum item aqui";
        DesativarSelecaoSlots();
        Time.timeScale = 1.0f;
        mainPlayer.GetComponent<MainPlayer>().enabled = true;
    }

    private void DesativarSelecaoSlots()
    {
        foreach (Slot slot in slots)
        {
            slot.ativo.enabled = false;
        }
    }

    // Seleciona um slot via mouse e atualiza descrição
    public void SelecionarSlot(int index)
    {
        if (!IsActive) return;

        slotSelec = index;
        DesativarSelecaoSlots();
        slots[slotSelec].ativo.enabled = true;

        if (!slots[slotSelec].IsEmpty())
        {
            descricao.text = slots[slotSelec].GetItem().descricao;
        }
        else
        {
            descricao.text = "Nao ha nenhum item aqui";
        }
    }

    // Deseleciona slot via mouse ao sair
    public void DeselecionarSlot()
    {
        if (!IsActive) return;

        slotSelec = -1;
        DesativarSelecaoSlots();
        descricao.text = "Nao ha nenhum item aqui";
    }

    // Adiciona item ao inventario: tenta aumentar qtd em slot igual, ou usa slot vazio
    public void AddItem(Item item)
    {
        foreach (Slot slot in slots)
        {
            if (slot.SameItem(item))
            {
                slot.GuardaItem(item);
                return;
            }
        }

        foreach (Slot slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.GuardaItem(item);
                return;
            }
        }
    }
}
