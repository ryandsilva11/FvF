using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //variáveis públicas
    public int slotIndex;
    public Inventario inventario;
    public Image ativo;
    public Image iconSlot;
    public TextMeshProUGUI quantidadeTexto;

    //variáveis privadas
    private Item itemGuardado;
    private int quantidade = 0;

    public bool IsEmpty()
    {
        return itemGuardado == null;
    }

    public Item GetItem()
    {
        return itemGuardado;
    }

    public bool SameItem(Item item)
    {
        return !IsEmpty() && itemGuardado.id == item.id;
    }

    // Agora esse método só adiciona item se estiver vazio, ou incrementa quantidade
    public void GuardaItem(Item item)
    {
        if (IsEmpty())
        {
            itemGuardado = item;
            quantidade = 1;
            iconSlot.sprite = item.icon;
            iconSlot.enabled = true;
        }
        else if (SameItem(item))
        {
            quantidade++;
        }
        AtualizarQuantidadeUI();
    }

    // Atualiza o texto da quantidade, esconde se for 1
    private void AtualizarQuantidadeUI()
    {
        quantidadeTexto.text = quantidade.ToString();
    }

    public void LimpaSlot()
    {
        itemGuardado = null;
        quantidade = 0;
        iconSlot.sprite = null;
        iconSlot.enabled = false;
        quantidadeTexto.text = "";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (inventario != null && Inventario.IsActive)
        {
            ativo.enabled = true;
            inventario.SelecionarSlot(slotIndex);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (inventario != null && Inventario.IsActive)
        {
            ativo.enabled = false;
            inventario.DeselecionarSlot();
        }
    }
}
