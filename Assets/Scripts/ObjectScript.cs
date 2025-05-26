using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Galvenais objekta skripts kas pārvalda spēles stāvokli un atsauces
public class ObjectScript : MonoBehaviour
{
    // Transportlīdzekļu objekti
    public GameObject medic;
    public GameObject garbageTruck;
    public GameObject schoolBus;
    public GameObject cementTruck;
    public GameObject b2;
    public GameObject e46;
    public GameObject e61;
    public GameObject exkavator;
    public GameObject policeCar;
    public GameObject traktor;
    public GameObject traktor5;
    public GameObject ugunsdzesēji;

    public AudioSource audioSource; // Skaņas atskaņotājs
    public AudioClip[] audioClips; // Skaņu klipi
    public GameObject completePanel; // Pabeigšanas panelis
    public GameObject star1, star2, star3; // Zvaigznes
    public Text timerText; // Taimeris uz ekrāna

    [HideInInspector] public bool rightPlace = false; // Vai objekts novietots pareizajā vietā
    public GameObject lastDragged = null; // Pēdējais vilktais objekts

    public int correctlyPlacedCount = 0; // Skaits cik objekti novietoti pareizi
    public HashSet<string> placedTags = new HashSet<string>(); // Unikālie tagi novietotajiem objektiem

    // Oriģinālās pozīcijas katram objektam
    [HideInInspector] public Vector2 medicPos;
    [HideInInspector] public Vector2 gTruckPos;
    [HideInInspector] public Vector2 sBusPos;
    [HideInInspector] public Vector2 cementTruckPos;
    [HideInInspector] public Vector2 b2Pos;
    [HideInInspector] public Vector2 e46Pos;
    [HideInInspector] public Vector2 e61Pos;
    [HideInInspector] public Vector2 exkavatorPos;
    [HideInInspector] public Vector2 policeCarPos;
    [HideInInspector] public Vector2 traktorPos;
    [HideInInspector] public Vector2 traktor5Pos;
    [HideInInspector] public Vector2 ugunsdzesējiPos;

    void Start()
    {
        // Saglabā sākotnējās pozīcijas lai vajadzības gadījumā varētu atgriezt
        medicPos = medic.GetComponent<RectTransform>().localPosition;
        gTruckPos = garbageTruck.GetComponent<RectTransform>().localPosition;
        sBusPos = schoolBus.GetComponent<RectTransform>().localPosition;
        cementTruckPos = cementTruck.GetComponent<RectTransform>().localPosition;
        b2Pos = b2.GetComponent<RectTransform>().localPosition;
        e46Pos = e46.GetComponent<RectTransform>().localPosition;
        e61Pos = e61.GetComponent<RectTransform>().localPosition;
        exkavatorPos = exkavator.GetComponent<RectTransform>().localPosition;
        policeCarPos = policeCar.GetComponent<RectTransform>().localPosition;
        traktorPos = traktor.GetComponent<RectTransform>().localPosition;
        traktor5Pos = traktor5.GetComponent<RectTransform>().localPosition;
        ugunsdzesējiPos = ugunsdzesēji.GetComponent<RectTransform>().localPosition;

        if (completePanel != null)
            completePanel.SetActive(false); // Sākumā paslēpj pabeigšanas paneli
    }
}
