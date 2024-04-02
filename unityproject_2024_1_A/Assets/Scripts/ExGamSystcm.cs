using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private int index;      //�� �� �ҹ���
    private string name;
    private ItemType type;
    private Sprite image;
    //�ɹ����� private �� ���� �Ұ�
    public int Index        //������Ƽ ���� (���� �̸� �� �� �빮��)
    {
        get { return index; }
        set { index = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public ItemType Type        //������Ƽ ���� Ŭ������ ����
    {
        get { return type; }
        set { type = value; }
    }

    public Sprite Image          //������Ƽ ���� ����Ƽ Ŭ������ ����
    {
        get { return Image; }
        set { Image = value; }
    }

    public Item(int index, string name, ItemType type)      //�������� ���� �ϴ� ������ �Լ� 
    {
        this.index = index;     //�� �������� �Լ��� �޾Ƽ� ������
        this.name = name;
        this.type = type;
    }
}

public enum ItemType        //������ ���� ����
{
    Weapon,
    Armor,
    Potion,
    QuestItem       //�ٸ� ������ Ÿ�Ե��� �߰� �Ҽ� �ִ�.
}

public class Inventory
{
    private Item[] items = new Item[16];

    //������ �ε���(Indexer)
    public Item this[int index]
    {
        get { return items[index]; }
        set { items[index] = value; }
    }

    //���� �κ��丮�� �ִ� ������ ��
    public int ItemCount
    {
        get
        {
            int count = 0;      //������ �� �˻縦 ���� ����
            foreach (Item item in items)
            {
                if (item != null) count++;       //�������� null�� �ƴϸ� +1
            }
            return count;
        }
    }

    //������ �߰�
    public bool AddItem(Item item)
    {
        for (int i = 0; i < items.Length; i++)       //����ĭ�� �˻� (for ������ �տ��� ���� �˻�)
        {
            if (items[i] == null)
            {
                items[i] = item;                    //�Լ��� ���� �������� �ִ´�.
                return true;
            }
        }
        return false;   //�κ��丮�� ���� á�� ���
    }

    //������ ���� 
    public void RemoveItem(Item item)
    {
        for (int i = 0; i < items.Length; i++)      //����ĭ�� �˻� (for ������ �տ��� ���� �˻�)
        {
            if (items[i] == item)                   //������ �������� �˻��ϰ�
            {
                items[i] = null;                    //null ���� �ִ´�.
                break;
            }
        }
    }
}

public class ExGameSystem : MonoBehaviour
{
    private Inventory inventory = new Inventory();  //�κ��丮 Ŭ���� ����

    void Start()
    {
        Item sword = new Item(0, "Sword", ItemType.Weapon);             //������ ���� Į ���� 
        Item shield = new Item(100, "Shield", ItemType.Armor);          //������ ���� ���� ����

        for (int i = 0; i < 5; i++)
        {
            inventory.AddItem(sword);                                       //������ �������� ���濡 �ִ´�. 
            inventory.AddItem(shield);
        }

        Debug.Log("Player Inventory : " + GetInventoryAsString());
    }
    private string GetInventoryAsString()
    {
        string result = "";
        for (int i = 0; i < inventory.ItemCount; i++)   //�κ��丮�ȿ� Item �� ������ �ش� �̸� ���
        {
            if (inventory[i] != null)
            {
                result += inventory[i].Name + ",";
            }
        }
        return result.TrimEnd(',');   //������ �޸� ���� 
    }
}