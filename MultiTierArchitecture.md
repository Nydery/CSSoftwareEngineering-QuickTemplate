Multi Tier Architecture
=======================

Die ***Multi Tier Architecture*** ist ein sehr häufig angewandtes Strukturmuster für die Architektur von Softwaresystemen. Das ***QuickTemplate*** implementiert ebenfalls diese Struktur. Die Struktur beinhaltet im Wesentlichen die 3 Schichten  

- Presentationsschicht,
- Geschäftslogik,
- und die Datenlogik.  

## Datenlogik

Auf der Datenebene werden alle datentechnische Belange abgebildet. Dazu gehören die Tabellen von Entitäten, deren Beziehungen und die Eigenschaften der Spalten (mandadory, Größen usw.). Im Falle einer Rechnung werden auf der Datenbank zwei Tabellen, Rechnungskopf und Rechnungsposition, benötigt. Diese Tabellen sind über eine Fremdschlüssel Beziehung miteinander verknüpft. Das Datensystem sorgt dafür, dass die Fremdschlüsselbeziehung eingehalten wird, dass erforderliche Werte (Not Null) eingehalten werden und die Größen der Datenwerte nicht überschritten werden. Alle Geschäftsregeln, welche auf die Datenebene übertragen werden können, sollen auch auf diesem System abgebildet werden. Dies hat den Vorteil, dass die Daten überprüft und validiert werden können.  

## Geschäftslogik  

Im Bereich der Domänenschicht werden grundsätzliche alle Logik-Regeln umgesetzt, welche von der Datenschicht nicht umgesetzt werden können. Dazu gehört die Regel - in unserem Beispiel der Rechnung, dass Rechnungen nur mit mindestens einer Detailposition im System vorhanden sein dürfen. Diese Regel ist schwierig bis unmöglich auf der Datenschicht abbildbar und sollte daher in der darüberliegenden Ebene unterbunden werden.

## Presentationsschicht  






![MultiTierAchitecture](MultiTierArchitecture.png)