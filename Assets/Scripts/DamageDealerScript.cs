using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageDealerScript : MonoBehaviour
{
    // Скрипт используется в префабах анимаций урона
    
    // Назначаем величину урона int
    [SerializeField] int damage = 100;

    // Метод GetDamage() возвращает величину int damage
    // Используется для нанесения урона NPC или игроку
    public int GetDamage()
    {
        return damage;
    }
    // Метод Hit() вызывается, когда происходит Collision анимации атаки с NPC или игроком. 
    // При вызове уничтожает копию объекта, на которой висит этот скрипт
    public void Hit()
    {
        Destroy(gameObject);
    }
}
