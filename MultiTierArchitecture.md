Multi Tier Architecture
=======================

Die ***Multi Tier Architecture*** ist ein sehr h�ufig angewandtes Strukturmuster f�r die Architektur von Softwaresystemen. Das ***QuickTemplate*** implementiert ebenfalls diese Struktur. Die Struktur beinhaltet im Wesentlichen die 3 Schichten  

- Presentationsschicht,
- Gesch�ftslogik,
- und die Datenlogik.  

## Datenlogik

Auf der Datenebene werden alle datentechnische Belange abgebildet. Dazu geh�ren die Tabellen von Entit�ten, deren Beziehungen und die Eigenschaften der Spalten (mandadory, Gr��en usw.). Im Falle einer Rechnung werden auf der Datenbank zwei Tabellen, Rechnungskopf und Rechnungsposition, ben�tigt. Diese Tabellen sind �ber eine Fremdschl�ssel Beziehung miteinander verkn�pft. Das Datensystem sorgt daf�r, dass die Fremdschl�sselbeziehung eingehalten wird, dass erforderliche Werte (Not Null) eingehalten werden und die Gr��en der Datenwerte nicht �berschritten werden. Alle Gesch�ftsregeln, welche auf die Datenebene �bertragen werden k�nnen, sollen auch auf diesem System abgebildet werden. Dies hat den Vorteil, dass die Daten �berpr�ft und validiert werden k�nnen.  

## Gesch�ftslogik  

Im Bereich der Dom�nenschicht werden grunds�tzliche alle Logik-Regeln umgesetzt, welche von der Datenschicht nicht umgesetzt werden k�nnen. Dazu geh�rt die Regel - in unserem Beispiel der Rechnung, dass Rechnungen nur mit mindestens einer Detailposition im System vorhanden sein d�rfen. Diese Regel ist schwierig bis unm�glich auf der Datenschicht abbildbar und sollte daher in der dar�berliegenden Ebene unterbunden werden.

## Presentationsschicht  






![MultiTierAchitecture](MultiTierArchitecture.png)