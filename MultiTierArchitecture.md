Multi Tier Architecture
=======================

Die ***Multi Tier Architecture*** ist ein sehr h�ufig angewandtes Strukturmuster f�r die Architektur von Softwaresystemen. Das ***QuickTemplate*** implementiert ebenfalls diese Struktur. Die Struktur beinhaltet im Wesentlichen die 3 Schichten  

- Presentationsschicht,
- Gesch�ftslogik,
- und die Datenlogik.  

## Datenlogik

Auf der Datenebene werden alle datentechnische Belange abgebildet. Dazu geh�ren die Tabellen von Entit�ten, deren Beziehungen und die Eigenschaften der Spalten (mandadory, Gr��en usw.). Im Falle einer Rechnung werden auf der Datenbank zwei Tabellen, ***Rechnungskopf*** und ***Rechnungsposition***, ben�tigt. Diese Tabellen sind �ber eine Fremdschl�ssel Beziehung miteinander verkn�pft und bilden somit eine **1:N-Beziehung**. Diese bedeutet, dass einem ***Rechnungskopf*** beliebeig viele ***Rechnungspositionen*** zugeordnet sein k�nnen(beliebig bedeutet 0..n).  
Das **Datensystem** sorgt daf�r, dass die Fremdschl�sselbeziehung eingehalten wird, dass erforderliche Werte (Not Null) definiert werden und die Gr��en der Datenwerte nicht �berschritten werden. Alle **Gesch�ftsregeln**, welche auf die Datenebene �bertragen werden k�nnen, sollen auch auf diesem System abgebildet werden. Dies hat den Vorteil, dass die Daten in letzter Instanz �berpr�ft und validiert werden k�nnen.  

## Gesch�ftslogik  

Im Bereich der Dom�nenschicht werden grunds�tzliche alle **Logik-Regeln** umgesetzt, welche von der Datenschicht nicht umgesetzt werden k�nnen. Dazu geh�rt die Regel - in unserem Beispiel der Rechnung, dass nur Rechnungen mit **mindestens** einer **Rechnungsposition** im System vorhanden sein d�rfen. Diese **Regel** ist schwierig bis unm�glich auf der Datenschicht abbildbar und sollte daher in der dar�berliegenden Ebene umgesetzt werden. Dies setzt allerdings voraus, dass alle Aktionen �ber den **Business-Layer** erfolgen. Aus diesem Grund muss die Architektur so konzipiert sein, dass der Zugriff auf die beiden Kontroller **Rechnungskopf** und **Rechnungsposition** au�erhalb des Projektes ***Invoice.Logic*** gesch�tzt sein muss.

## Presentationsschicht  

In der Presentationsschicht befinden sich in den meisten F�llen viele unterschiedliche Anwendungen welche, auf den Backend zugreifen. Diese k�nnen vom physikalischen Aufbau sehr unterschiedlich sein. So gibt es Klienten welche ebenfalls in CSharp implementiert worden sind. Dadurch ergibt sich die M�glichkeit, dass diese Anwendungen direkt auf den Backend zugreifen k�nnen. Es gibt aber auch Endger�te die nicht in CShrap implememntiert worden sind oder keine M�glichkeit des direkten Zugriffs auf das Backend haben (z.B.: Handy). F�r den indirekten Zugriff auf das Backend gibt es einen REST Service. Dieser erlaubt einen Zugriff �ber das HTTP-Protokoll. Mit diesem Service ergibt sich ein uneingeschr�nkte Zugriff auf den Backend.

In der nachfolgenden Abbildung ist die Architektur schematisch dargestellt: 


![MultiTierAchitecture](MultiTierArchitecture.png)