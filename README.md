# Lern-Periode-6
## 16/08/2024
### Grobplanung:
In dieser LP möchte ich:
- Sichergehen dass ich bei den Modulen nicht hinter den Zeitplan der Module falle.
- Ein Projekt starten welches es mir ermöglicht meine CySec-Kentnisse zu erweitern.
    - (Ich habe ^^^ auf meine Freizeit ausgelagert, um mich hier ein wenig mehr auf die Module zu konzentrieren.)


## 23/08/2024
### Arbeitspakete
- [x] M320 Auftrag 4 fertig machen
- [x] M320 Auftrag 5
- [x] M320 Auftrag 6

## 30/08/2024
### Arbeitspakete
- [x] M231 1713 Passwoerter
- [x] Ideen für ein mögliches Projekt sammeln
- [x] Projekt beginnen

Ich habe einige Ideen gesammelt, aber ich bin mir noch nicht sicher ob diese noch zu ambitioniert sind. Egal, ich finde es heraus und habe mal angefangen. 

## 06/09/2024
### Arbeitspakete
- [x] Mit Cezar OOP repetieren
- [x] M231 Bedrohungskategorien Repetieren
- [x] Am Projekt weiterarbeiten.

## 06/09/2024
### Arbeitspakete
- [x] M320 OOP - Polymorphismus mit Cezar repetiert
- [x] M320 OOP - OBA verfeinert
- [x] M320 OOP - Tests und Dokumentation

## 20/09/2024
### Arbeitspakete
- [x] M320 OOP - 4217 Unit Testing
- [x] M259 ML  - 1651 sklearn on your own
- [x] M259 ML  - 1652 Weitere Algorithmen

### Gelerntes
- Perceptron -> Neuronales Netzwerk mit nur 2 bzw. 1 Layer, kann nur linear lösbare Probleme lösen.
- K-NearestNeighbor -> Simpler ML-Algorithmus der für Klassifizierung und Regression verwendet werden kann.
- RandomizedSearchCV -> Einfache zu benutzende, in sklearn integrierte Methode um die optimale Konfiguration,
                        bzw. eine bessere Konfiguration für Algorithmen wie zb. KNN zu finden. Dabei werden
                        verschiedene Werte ausprobiert, und die Kombinationen, die die besten Ergebnisse
                        geliefert haben, können über `_best_params` ausgelesen werden.                        
- Unit Testing -> Automatisierte Tests in VS. Diese können (nach leichter Modifikation beim Code des Projektes
                  um Zugriff auf geschützte Klassen zuzulassen) für Tests verwendet werden. Dies bringt den
                  Vorteil, dass nun Standartisierte Tests möglich sind und das Ganze nicht mehr von Hand
                  gemacht werden muss.
### Schwierigkeiten
Bei Unit Testing konnte ich kein Projekt importieren, ich habe dann aber bald gemerkt, dass es funktioniert wenn man die .exe und .dll Dateien des Projektes importiert. Um Änderungen am Code des Original-Projektes zu speichern, muss man dieses einfach nochmals ausführen, was zu einer aktualisierung der .exe und .dll Dateien führt. Diese werden im MSTest-Projekt automatisch neu geladen.

### Reflektion
Ich habe die gesetzten Arbeitsaufträge gut erfüllt und bin auf kaum Schwierigkeiten gestossen. Ich habe einiges gelernt und die ganze ML-Sache ist nun auch schon ein wenig Intiutiver. Beim Modul 320 OOP habe nun HZ4 abgeschlossen und bin somit 1 HZ voraus. (HZ4 war aber nur dieser eine Auftrag den ich jetzt gemacht habe) Die beiden Aufträge vom Modul 259 habe ich heute auch fertig gelöst. Am Auftrag 1651 hatte ich am längsten, da ich dort auch wirklich noch selbst mit Parametern und Verschiedenen Input-Daten experimentiert habe. Mein bestes Ergebnis kam auf 80% genauigkeit (Voraussage mit Titanik-Datensatz)

## 27/09/2024
### Arbeitspakete
- [x] M320 OOP - Lernauftrag ZombieSurvival Spieler und Movement programmieren
- [x] M320 OOP - ZS: Hindernisse und Collision detection Programmieren (Spieler kann nicht auf Felder, an denen Hindernisse stehen
- [x] M320 OOP - ZS: Mine die ausgelöst wird wenn der Spieler eine bestimmte distanz entfernt ist und Ihm dann Schaden zufügt.
- [x] M320 OOP - ZS: Zombie der in auf den Spieler zuläuft.
- [x] M320 OOP - ZS: Einen Weg finden, wie der Spieler den Zombie besiegen kann + implementation

### Gelerntes
- tuples in c# -> tupel können so: `(int, int) tupelName` erstellt werden. Was praktisch ist, auch für das 
                  ZombieSurvivor Spiel, ist das auch die Variabeln im Tupel benannt werden können 
                  `(int X, int Y) _coordinates` darauf kann danach mit `_coordinates.Y` zugegriffen werden.
- dynamische 2D-Arrays -> Arrays können ja mit `char[] charArray` erstellt werden. Nun können aber auch
                          2D-Arrays erstellt werden. Dies sieht dann so aus: `char[,] charArray`. Das beste 
                          daran ist, dass die grösse dieses Arrays dynamisch erstellt werden kann, was es mir
                          erlaubt, unterschiedlich grosse Game-Welten zu erstellen.
- Darstellung von Arrays -> Ich habe einen 2D-Array für mein Spielfeld erstellt. Auf diesem muss sich der Spieler
                            bewegen können. Dafür hat die Elements-Klasse, von der auch die Spieler-Klasse erbt, 
                            ein Coordinates attribut. Die Elemente befinden sich nicht wirklich in dem Array, sondern
                            sie werden mit Ihren Coordinaten in den Array gezeichnet. `_buffer[element.Coordinates.y, element.Coordinates.x] = element.Symbol;`
- Collision detection -> Um in meinem Spiel-Array (_buffer) Kollisionen zu erkennen habe ich eine Liste erstellt, in 
                         dem ich alle Koordinaten neben dem Spieler erkenne. Das ganze ist [hier](#collision-detection) zu finden.

- Zombie in richtung Spieler bewegen -> Um den Zombie in Richtung Spieler zu bewegen, habe ich ihm ein `_target`-Element
                                        zur verfügung gestellt. Er greift dann auf die Koordinaten seines Ziels zu und
                                        verwendet [diesen](#2D-direction) Code-Block um sich ein Feld in dessen Richtung zu bewegen.
- Console.ReadKey() -> Es ist möglich auf eine einzelne Taste zu warten und diese als Input zu verwenden anstatt einen String.
                       `ConsoleKeyInfo key = Console.ReadKey();` um den Input als Char zu erhalten kann man folgenderweise darauf
                       zugreifen: `_world.HandlePlayerInputs(key.KeyChar);`

### Schwierigkeiten
Ich hatte ein kleines Problem beim Debugging des Spieler Inputs. Die Bewegungen des Spielers stimmten nicht mit meinen WASD-Inputs überein. Dies liegt vermutlich an der verworrenheit meines [Movement-Code-Blocks](#movement) und daran, dass "oben" im Array 0 ist und ich deshalb von der X-Koordinate Abziehen muss um den Spieler nach "oben" zu bewegen. Dies ist aber bei der Y-Koordinate nicht so.
Zudem hatte ich ein Problem, bei dem der Game-Over-Screen doppelt angezeigt wurde. Das habe ich dann aber durch eine zusätzliche Variable `_isLastPrintBeforeGameOver` gelöst. Es gab noch weitere komische Fälle, bei denen die Überprüfung des Nachbarfelders nicht klappte, aber mit der aktuellen Lösung ist dies kein Problem mehr.

### Reflektion
Ich habe heute gut und effizient gearbeitet und habe alle meine Ziele erfüllt. Ich habe sogar noch eine Game-Over-Screen eingebaut was nicht geplant war. Diese Aufgabe ist die letzte Übung des Moduls 320 OOP und ist auch dementsprechend gross. Es ist jedoch eine sehr gute Übung und mir ist nun einiges klarer und intuitiver als zuvor (Vererbung, Polymorphismus, base() ). 
Ich werden meinen aktuellen Stand Auf Github laden um Ihnen Zugriff zu ermöglichen. Falls sie es Ausprobieren möchten, die Bewegungscontrols sind WASD und angreifen ist die Taste 1 (Mir ist nichts besseres eingefallen) es existiert noch kein Game-Loop und das Spiel wird nur nach Spieler-Inputs geupdatet.




# Code Blocks

## Collision-Detection
```C#
(int, int)[] nextToPlayer = [(0, 1), (1, 0), (0, -1), (-1, 0), (0, 0)];

if (nextToPlayer.Contains((element.Position.x - _player.Position.x, element.Position.y - _player.Position.y)))
{
    // Handling of damage and collision
}
```

## 2D-direction
```C#
(int x, int y) directionToMove;
// set X
if ((_target.Position.x - _posX) >= 1)
{
    directionToMove.x = 1;
} else if ((_target.Position.x - _posX) == 0)
{
    directionToMove.x = 0;
} else {
    directionToMove.x = -1;
}

// set Y
if ((_target.Position.y - _posY) >= 1)
{
    directionToMove.y = 1;
}
else if ((_target.Position.x - _posY) == 0)
{
    directionToMove.y = 0;
}
else
{
    directionToMove.y = -1;
}

// move
Move(directionToMove);
```

## Movement
```C#
(int X, int Y) _directionToMove;
bool _playerIsAttacking = false;

// set the move direction
switch (key)
{
    case 'w':
        _directionToMove = (1, 0);
        break;
    case 's':
        _directionToMove = (-1, 0);
        break;
    case 'a':
        _directionToMove = (0, -1);
        break;
    case 'd':
        _directionToMove = (0, 1);
        break;
    case '1':
        _directionToMove = (0, 0);
        _playerIsAttacking = true;
        break;
    default:
        _directionToMove = (0, 0);
        break;
}

// move the player
if (_directionToMove.X == -1)
{
    if (_player.Position.x + 1 < SIZE_X && PeekAt(_player.Position.x + 1, _player.Position.y) != '#')
    {
        _player.Move(1, 0);
    }
}
if (_directionToMove.X == 1)
{
    if (_player.Position.x - 1 > 0 && PeekAt(_player.Position.x - 1, _player.Position.y) != '#')
    {
        _player.Move(-1, 0);
    }
}

if (_directionToMove.Y == 1)
{
    if (_player.Position.y + 1 < SIZE_Y && PeekAt(_player.Position.x, _player.Position.y + 1) != '#')
    {
        _player.Move(0, 1);
    }
}
if (_directionToMove.Y == -1)
{
    if (_player.Position.y - 1 > 0 && PeekAt(_player.Position.x, _player.Position.y - 1) != '#')
    {
        _player.Move(0, -1);
    }
}
```
