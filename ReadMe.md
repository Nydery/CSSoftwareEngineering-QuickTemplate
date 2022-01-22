
# QuickTemplate

Das Projekt ***QuickTemplate*** ist eine Vorlage f�r die Erstellung von datenzentrierten Anwendungen. Ausgehend von dieser Vorlage
k�nnen neue Anwendungen erstellt und erweitert werden. 

# Inhaltsverzeichnis
1. [Infrastruktur](#infrastruktur)
2. [Template](#template)
3. [Entwicklerwerkzeuge](#entwicklerwerkzeuge)
4. [Verwendung der Vorlage](#verwendung-der-Vorlage)
   1. [Projekterstellung](#projekterstellung)
   2. [Abgleich mit dem QuickTemplate](#abgleich-mit-dem-quicktemplate)
5. [Umsetzungsschritte](#Umsetzungsschritte)

## Infrastruktur

Zur Umsetzung des Projektes wird DotNetCore (6.0 und h�her) als Framework, die Programmiersprache CSharp (C#) und die Entwicklungsumgebung Visual Studio 2022 Community verwendet. Alle Komponenten k�nnen kostenlos aus dem Internet heruntergeladen werden.

In diese Dokumentation werden unterschiedlichste Begriffe verwendet. In der nachfolgenden Tabelle werden die wichtigsten Begriffe zusammengefasst und erl�utert:

|Begriff|Bedeutung|Synonym(e)|
|---|---|---|
|**Solution**|Ist der Zusammenschluss von verschiedenen Teilprojekten zu einer Gesamtl�sung.|Gesamtl�sung, L�sung, Projekt|
|**Domain Solution**|Hier ist eine Gesamtl�sung gemeint, welches f�r einen bestimmten Problembereich eine L�sung darstellt.|Probleml�sung, Projekt|
|**Teilprojekt**|Ist die Zusammenstellung von Klassen und/oder Algorithmen, welches eine logische Einheit f�r die L�sungen bestimmter Teilprobleme bildet.|Teill�sung, Projekteinheit, Projekt|
|**Projekttyp**|Unter Projekttyp wird die physikalische Beschaffenheit eines Projektes bezeichnet. Es gibt zwei grundlegende Typen von Projekten. Zum einen gibt es einen wiederverwendbaren und zum anderen einen ausf�hrbaren Projekttyp. <br>**Als Regel gilt:**<br> Alle Programmteile werden in wiederverwendbare Projekte implementiert. Die ausf�hrbaren Einheiten dienen nur als Startprojekte und leiten die Anfragen an die wiederverwendbaren Projekt-Komponenten weiter.|Bibliothekstyp, Consolentyp|
|**Libray**|Kennzeichnet einen wiederverwendbaren Projekttyp.|Bibliothek|
|**Console**|Kennzeichnet einen ausf�hrbaren Projekttyp. Dieser Typ startet eine Konsole f�r die Ausf�hrung.|Konsole|
|**Host**|Dieser Typ kennzeichnet ein ausf�hrbares Projekt, welches zum Starten den IIS verwendet oder im Modus 'selfhosting' gestartet werden kann.|Web-Application |
|**Abh�ngigkeit**|Die Abh�ngikeit beschreibt die Beziehungen von Projekten untereinander. Ben�tigt ein Projekt Funktionalit�ten aus einem andern Projekt, so wird eine Projektreferenz zum anderen Projekt ben�tigt.|Projektreferenz, Referenz, Dependency, Projektverweis|

## Template
Die Struktur vom 'QuickTemplate' besteht aus unterschiedlichen Teilprojekten und diese in einer Gesamtl�sung (im Kontext von Visual Studio ist das eine Solution) zusammengefasst. Eine Erl�uterung der einzelnen Projekte, deren Typ und die Abh�ngigkeit finden sie in der folgenden Tabelle:

|Projekt|Beschreibung|Typ|Abh�ngigkeit|
|---|---|---|---|
|**CommonBase**|In diesem Projekt werden alle Hilfsfunktionen und allgemeine Erweiterungen zusammengefasst. Diese sind unabh�ngig vom Problembereich und k�nnen auch in andere Dom�n-Projekte wiederverwendet werden.|Library|keine|
|**QuickTemplate.Logic**|Dieses Projekt beinhaltet den vollst�ndigen Datenzugriff, die gesamte Gesch�ftslogik und stellt somit den zentralen Baustein des Systems dar.|Library|CommonBase|
|**QuickTemplate.WebApi**|In diesem Projekt ist die REST-Schnittstelle implementiert. Diese Modul stellt eine API (Aplication Programming Interface) f�r den Zugriff auf das System �ber das Netzwerk zur Verf�gung.|Host|CommonBase, QuickTemplate.Logic|
|**QuickTemplate.ConApp**|Dieses Projekt dient als Initial-Anwendung zum Erstellen der Datenbank, das Anlegen von Anmeldedaten falls die Authentifizierung aktiv ist und zum Importieren von bestehenden Daten. Nach der Initialisierung wird diese Anwendung kaum verwendet.|Console|CommonBase, QuickTemplate.Logic|
|**QuickTemplate.AspMvc**|Diese Projekt beinhaltet die Basisfunktionen f�r eine AspWeb-Anwendung und kann als Vorlage f�r die Entwicklung einer einer AspWeb-Anwendung mit dem QuickTemplate verwendet werden.|Host|CommonBase, QuickTemplate.Logic|
|**QuickTemplate.WpfApp**|Diese Projekt beinhaltet die Basisfunktionen f�r eine Wpf-Anwendung und kann als Vorlage f�r die Entwicklung einer einer Wpf-Anwendung mit dem QuickTemplate Framework verwendet werden.|Host|CommonBase, QuickTemplate.Logic|
|**QuickTemplate.XxxYyy**|Es folgen noch weitere Vorlagen von Client-Anwendungen wie Angular, Blazor und mobile Apps. Zum jetzigen Zeitpunkt existiert nur die AspMvc-Anwendung. Die Erstellung und Beschreibung der anderen Client-Anwendungen erfolgt zu einem sp�teren Zeitpunkt.|Host|CommonBase, QuickTemplate.Logic|

## Entwicklerwerkzeuge
Dem Entwickler stehen unterschiedliche Hilfsmittel f�r die Erstellung von Projekten zur Seite. Die wichtigsten Werkzeuge sind in der nachfolgenden Tabelle zusammengefasst:

|Projekt|Beschreibung|Typ|Abh�ngigkeit
|---|---|---|---|
|**TemplateCopier.ConApp**|Diese Anwendung dient zum Kopieren des ***QuickTemplate***. Die Vorlage dient als Basis f�r viele zuk�nftige Projekte und muss dementsprechend kopiert werden. Der *TemplateCopier* kopiert alle Teilprojekte in den Zielordner und f�hrt eine Umbenennung der Komponenten durch.|Console|CommonBase
|**TemplateComparsion.ConApp**|Dieses Projekt dient zum Abgleich aller mit dem Template erstellten Dom�n-Projekten.|Console|CommonBase

# Verwendung der Vorlage  

Nachfolgend werden die einzelnen Schritte von der Vorlage ***QuickTemplate*** bis zum konkreten Projekt ***QTMusicStoreLight*** erl�utert. Das Projekt ist eine einfache Anwendung zur Demonstration von der Verwendung der Vorlage. Im Projekt ***QTMusicStoreLight*** werden K�nstler (Artisten) und deren produzierten Alben verwaltet. Jedes Album hat ein Genre (Rock, Pop, Klassik usw.) zugeordnet. Ein Datenmodell ist im nachfolgendem Abschnitt definiert.
 
## System-Erstellungs-Prozess

Wenn nun ein einfacher Service oder eine Anwendung entwickelt werden soll, dann kann die Vorlage ***QuickTemplate*** als Ausgangsbasis verwendet und weiterentwickelt werden. Dazu empfiehlt sich folgende Vorgangsweise:  

### Vorbereitungen

- Erstellen eines Ordners (z.B.: Develop)
- Herunterladen des Repositories ***QuickTemplate*** vom [GitHub](<https://github.com/leoggehrer/CSSoftwareEngineering-QuickTemplate>) und in einem Ordner speichern.  

> **ACHTUNG:** Der Solution-Ordner von der Vorlage muss ***QuickTemplate*** hei�en.

### Projekterstellung
Die nachfolgenden Abbildung zeigt den schematischen Erstellungs-Prozess f�r ein Domain-Projekt:  

![Create domain project overview](CreateProjectOverview.png)  

Als Ausgangsbasis wird die Vorlage ***QuickTemplate*** verwendet. Diese Vorlage wird mit Hilfe dem Hilfsprogramm ***'TemplateCopier.ConApp'*** in ein Verzeichnis eigener Wahl kopiert. In diesem Verzeichnis werden alle Projektteile (mit Ausnahme der Hilfsprogramme *TemplateCopier.ConApp* und *TemplateComparison.ConApp*) von der Vorlage kopiert und die Namen der Projekte und Komponenten werden entsprechend angepasst. Alle Projekte mit dem Prefix ***QuickTemplate*** werden mit dem domainspezifischen Namen des Verzeichnisses ersetzt. Beim Kopieren der Dateien von der Vorlage werden alle Dateien mit dem Label ***@BaseCode*** durch den Label ***@CodeCopy*** ersetzt. Diese Label werden f�r den Abgleich-Prozess verwendet.

Zum Beispiel soll ein Projekt mit dem Namen 'QTMusicStoreLight' erstellt werden. Im 'TemplateCopier' werden folgende Parameter eingestellt:  

```csharp
Solution copier!
================

Copy 'QuickTemplate' from: ...\source\repos\HtlLeo\CSSoftwareEngineering\QuickTemplate
Copy to 'QTMusicStoreLight':   ...\source\repos\HtlLeo\CSSoftwareEngineering\QTMusicStoreLight

[1] Change target path
[2] Change target solution name
[3] Start copy process
[x|X] Exit

Choose: 3
```

**Hinweis:** Die Vorlage muss im Ordner (*QuickTemplate*) gespeichert sein.  

Nach der Ausf�hren der Option ***'[3] Start copy process'*** befindet sich folgende Projektstruktur im Ordner **...\QTMusicStoreLight**:  

- CommonBase
- QTMusicStoreLight.AspMvc
- QTMusicStoreLight.ConApp
- QTMusicStoreLight.Logic
- QTMusicStoreLight.WebApi
- QTMusicStoreLight.WpfApp

Im Projekt ***QuickTemplate*** sind alle Code-Teile, welche als Basis-Code in andere Projekte verwendet werden, mit einem Label ***@BaseCode*** markiert. Dieser Label wird im Zielprojekt mit dem Label ***@CodeCopy*** ersetzt. Das hat den Vorteil, dass �nderungen in der Vorlage auf die bereits bestehenden Projekte �bertragen werden k�nnen (n�here Informationen dazu gibt es sp�ter).  

> **ACHTUNG:** Im Domain-Projekt d�rfen keine �nderungen von Dateien mit dem Label ***@CodeCopy*** durchgef�hrt werden, da diesen beim n�chsten Abgleich wieder �berschrieben werden. Sollen dennoch �nderungen vorgenommen werden, dann muss der Label ***@CodeCopy*** ge�ndert (z.B.: @CustomCode) oder entfernt werden. Damit wird diese Datei vom Abgleich, mit der Verlage, ausgeschlossen.

## Abgleich mit dem QuickTemplate

In der Software-Entwicklung gibt es immer wieder Verbesserungen und Erweiterungen. Das betrifft die Vorlage ***QuickTemplate*** genauso wie alle anderen Projekte. Nun stellt sich die Frage: Wie k�nnen Verbesserungen und/oder Erweiterungen von der Vorlage auf die Domain-Projekte �bertragen werden? In der Vorlage sind die Quellcode-Dateien mit den Labels ***@BaseCode*** gekennzeichnet. Beim Kopieren werden diese Labels durch den Label ***@CodeCopy*** ersetzt. Mit dem Hilfsprogramm *TemplateComparison.ConApp* werden die Dateien mit dem Label ***@BaseCode*** und ***@CodeCopy*** abgeglichen. In der folgenden Skizze ist dieser Prozess dargestellt:

![Template-Comparsion-Overview](TemplateComparsionOverview.png)

F�r den Abgleichprozess m�ssen im Projekt ***TemplateComparsion.ConApp*** in der Datei ***Program.cs*** folgende Eintellungen definiert werden:

```csharp
    // QuickTemplate-Projects
    TargetPaths = new string[]
    {
        Path.Combine(UserPath, @"source\repos\HtlLeo\CSSoftwareEngineering\QTMusicStoreLight"),
    };
    // End: QuickTemplate-Projects
```

Im n�chsten Schritt wird die Anwendung ***TemplateComparsion.ConApp*** gestartet. Der folgende Benutzer-Dialog wird angezeigt:  

```csharp
TemplateComparison:
==========================================

Source: ...\source\repos\HtlLeo\CSSoftwareEngineering\QuickTemplate\

   Balancing for: [ 1] ...\source\repos\HtlLeo\CSSoftwareEngineering\QTMusicStoreLight
   Balancing for: [ a] ALL


Balancing [1..1|X...Quit]:
```

Wird nun die Option **[1 oder a]** aktiviert, dann werden alle Dateien im Projekt **QuickTemplate** mit der Kennzeichnung **@BaseCopy** mit den Dateien im Projekt **QTMusicStoreLight** mit der Kennzeichnung **@CodeCopy** abgeglichen.  

# Umsetzungsschritte  

Nachdem nun das Domain-Projekt **QTMusicStoreLight** erstellt wurde, werden nun folgende Schritte der Reihenfolge nach ausgef�hrt:

- Erstellen der Entit�ten
- Definition des Datenbank-Kontext
- Erstellen der Kontroller
- Erstellen der Datenbank
- Importieren von Daten

Die einzelnen Schritte sind im [Github-QTMusicStoreLight](https://github.com/leoggehrer/CSSoftwareEngineering-QTMusicStoreLight) detailiert aufgef�hrt.

**Viel Spa� beim Umsetzen der Aufgabe!**
