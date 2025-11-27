# IPT5.1_Stundenplaner-Projekt

## 📘 Kurzbeschreibung

Der **Stundenplaner** ist ein C#-basiertes Tool, das automatisch Stundenpläne für Schulklassen erstellt.
Das Programm verwaltet **Lehrer**, **Schüler**, **Klassen**, **Räume** und **Fächer** und erzeugt daraus einen möglichst sinnvollen Wochenplan.
Der Algorithmus berücksichtigt Verfügbarkeiten, Raumkapazitäten, Fachzuweisungen und bewertet jeden Plan nach Randzeiten, Zwischenstunden und Raumnutzung.

Daten werden lokal als **JSON** gespeichert und beim Start automatisch geladen.

---

## ▶️ Startanleitung

1. **Programm starten**
   Nach dem Start erscheint das Hauptmenü:

   ```
   0: Raum Infos/bearbeiten
   1: Lehrer Infos/bearbeiten
   2: Fach Infos/bearbeiten
   3: Schulklasse Infos/bearbeiten
   4: Schüler Infos/bearbeiten
   5: Stundenplan Infos/bearbeiten
   6: Beenden
   ```

2. **Grunddaten einrichten**
   Bevor ein Stundenplan erstellt werden kann, musst du genügend Ressourcen anlegen:

   * Räume
   * Lehrer (inkl. Fächer & Verfügbarkeit)
   * Schüler
   * Klassen

3. **Stundenplan erstellen**
   Menüpunkt **5 → 1** auswählen.
   Danach Gewichtungen einstellen:

   * Randzeiten (0–20)
   * Zwischenstunden (0–20)
   * Raumnutzung (0–40)

4. **Stundenplan ansehen**
   Menüpunkt **5 → 0** zeigt alle fertigen Pläne an.

5. **Daten bleiben erhalten**
   Das System speichert alles automatisch in JSON-Dateien – nach einem Neustart werden die Daten wieder geladen.