using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

public class Characters
{
    public static bool agarrate;
    public static bool notthis;
    public static bool pared;
    public static bool dupliquiti;
    public static bool viandazo;
    public static bool lechazo;
    public static Random trampita = new Random();
    public static int trampitrampi;


    public string Name { get; private set; }
    public int Movement { get; set; }
    public int Originmovement { get; set; }
    public int AffectedMovement { get; set; }
    public int PowerCooldown { get; set; }

    public string Power { get; private set; }
    public string PowerDescription { get; private set; }

    public Characters(string name, int movement, int originmovement, int affectedMovement, int powercooldown, string power, string powerdescription)
    {
        Name = name;
        Movement = movement;
        Originmovement = originmovement;
        AffectedMovement = affectedMovement;
        PowerCooldown = powercooldown;
        Power = power;
        PowerDescription = powerdescription;
    }
    public void Recogedor()
    {
        Movement = Originmovement;
    }
    public static void Poderes(string name)
    {
        if (name == "Karlach")
        {
            agarrate = true;

        }
        if (name == "Astarion")
        {
            trampitrampi = trampita.Next(1, 5);
        }
        if (name == "Gale")
        {
            pared = true;
        }
        if (name == "Shadowheart")
        {
            dupliquiti = true;
        }
        if (name == "Laezel")
        {
            viandazo = true;
        }
        if (name == "Wyll")
        {
            lechazo = true;
        }
    }



















}










