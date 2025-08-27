// Taller#1 POO
using System;
using System.Security.Cryptography.X509Certificates;

public class Time
{
    private int hours;
    private int minutes;
    private int seconds;
    private int milliseconds;

    //Constructor (#1) sin parámetros
    public Time()
    {
        hours = 0;
        minutes = 0;
        seconds = 0;
        milliseconds = 0;
    }

    //Constructor (#2) con horas
    public Time(int hours)
        {
            this.hours = hours;
            minutes = 0;
            seconds = 0;
            milliseconds = 0;
        }

    //Constructor (#3) con horas y minutos
    public Time(int h, int m)
        {
            this.hours = hours;
            this.minutes = m;
            seconds = 0;
            milliseconds = 0;
    }

    //Constructor (#4) con horas, minutos y segundos
    public Time(int h, int m, int s)
        {
            this.hours = hours;
            this.minutes = m;
            this.seconds = s;
            milliseconds = 0;
    }

    //Constructor (#4) con horas, minutos, segundos y milisegundos
    public Time(int h, int m, int s, int ms)
        {
            this.hours = hours;
            this.minutes = m;
            this.seconds = s;
            this.milliseconds = ms;
    }

    // Método validar (si) la hora es válida
    private bool IsValidTime(int hours, int m, int s, int ms)
    {
        if (hours < 0 || hours > 23) return false;
        if (m < 0 || m > 59) return false;
        if (s < 0 || s > 59) return false;
        if (ms < 0 || ms > 999) return false;
        return true;
        
    }

    // Método ToString - Formato 12 horas con AM/PM
    public override string ToString()
    {
        if (!IsValidTime(0, 0, 0, 0))
        {
            throw new ArgumentException("Hora no válida");
        }
      

        string lapsoT = hours >= 12 ? "PM" : "AM";
        int displayHours = hours % 12;
        if (displayHours == 0) displayHours = 12; // Convertir 0 horas a 12 en formato 12 horas

        return $"{displayHours:D2}:{minutes:D2}:{seconds:D2}.{milliseconds:D3} {lapsoT}";
    }

    // Método ToMilliseconds
    public long ToMilliseconds()
    {
        if (!IsValidTime(0, 0, 0, 0))
        {
           return 0;
        }
        return (hours * 3600000) + (minutes * 60000) + (seconds * 1000) + milliseconds;
    }

    // Método ToSeconds
    public long ToSeconds()
    {
        if (!IsValidTime(0, 0, 0, 0))
        {
            return 0;
        }
        return (hours * 3600) + (minutes * 60) + seconds + (milliseconds / 1000);
    }

    // Método ToMinutes
    public long ToMinutes()
    {
        if (!IsValidTime(0, 0, 0, 0))
        {
           return 0;
        }
        return (hours * 60) + minutes + (seconds / 60) + (milliseconds / 60000);
    }

    // Método IsOtherDay
    public bool IsOtherDay(Time other)
    {
        if (!IsValidTime(0, 0, 0, 0) || !other.IsValidTime(0, 0, 0, 0))
        {
           return false;
        }
        long totalMilliseconds = this.ToMilliseconds() + other.ToMilliseconds();
        return totalMilliseconds >= 86400000; // 24 horas en milisegundos equivale a 86400000 ms
    }

    // Método Add
    public Time Add(Time otherTime)
    {
        if (!IsValidTime(0, 0, 0, 0) || !otherTime.IsValidTime(0, 0, 0, 0))
        {
           return new Time();
        }
        long totalMilliseconds = this.ToMilliseconds() + otherTime.ToMilliseconds(); // Suma de milisegundos de ambas horas
        long days = totalMilliseconds / 86400000; // Cantidad de días completos en los milisegundos totales
        long remainingMilliseconds = totalMilliseconds % 86400000; // Milisegundos restantes después de contar los días
        int newHours = (int)((totalMilliseconds / 3600000) % 24); // Horas restantes en formato 24 horas
        int newMinutes = (int)((totalMilliseconds / 60000) % 60); // Minutos restantes
        int newSeconds = (int)((totalMilliseconds / 1000) % 60); // Segundos restantes
        int newMilliseconds = (int)(totalMilliseconds % 1000); // Milisegundos restantes
        return new Time(newHours, newMinutes, newSeconds, newMilliseconds); // Retorna una nueva instancia de Time con la suma de ambas horas
    }
}

