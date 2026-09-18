# Product backlog - Busverhuur adminpanel

## Doel

Medewerkers van het busverhuurbedrijf kunnen voertuigen, klanten en
reserveringen beheren vanuit een overzichtelijk adminpanel.

## Must haves

| Prioriteit | User story | Acceptatiecriteria |
| --- | --- | --- |
| Must | Als medewerker wil ik een overzicht van alle reserveringen zien, zodat ik weet welke voertuigen zijn ingepland. | Het overzicht toont klant, voertuig, startdatum, einddatum en betaalstatus. |
| Must | Als medewerker wil ik voertuigen kunnen bekijken, zodat ik schade en kilometerstanden kan controleren. | Het voertuigenoverzicht toont kenteken, type, zitplaatsen, afbeelding, km-stand en schade. |
| Must | Als medewerker wil ik een voertuig kunnen toevoegen, zodat nieuwe bussen beschikbaar worden voor reserveringen. | Een formulier slaat een nieuw voertuig met geldige gegevens op in SQLite. |
| Must | Als medewerker wil ik voertuiggegevens kunnen aanpassen, zodat de vlootgegevens actueel blijven. | Kenteken, type, zitplaatsen, afbeelding, km-stand en schade zijn te wijzigen. |
| Must | Als medewerker wil ik een voertuig kunnen verwijderen, zodat voertuigen die niet meer in gebruik zijn verdwijnen. | Verwijderen vraagt om bevestiging en werkt niet wanneer het voertuig nog reserveringen heeft. |
| Must | Als medewerker wil ik een reservering kunnen toevoegen, zodat een klant een voertuig kan boeken. | Een reservering koppelt een klant, voertuig, begin- en einddatum aan elkaar. |
| Must | Als medewerker wil ik de betaalstatus van een reservering kunnen bijwerken, zodat ik openstaande betalingen kan opvolgen. | Een reservering kan als betaald of openstaand worden opgeslagen en weergegeven. |
| Must | Als medewerker wil ik begin- en eindkilometerstanden bij een reservering opslaan, zodat gereden kilometers kunnen worden bijgehouden. | Begin- en eindstand zijn zichtbaar en de eindstand mag niet lager zijn dan de beginstand. |

## Should haves

| Prioriteit | User story | Acceptatiecriteria |
| --- | --- | --- |
| Should | Als medewerker wil ik klanten kunnen bekijken, zodat ik hun contactgegevens bij een reservering kan gebruiken. | Een klantenoverzicht toont naam, e-mail, telefoonnummer en adres. |
| Should | Als medewerker wil ik klanten kunnen toevoegen en aanpassen, zodat klantgegevens juist blijven. | Klantgegevens kunnen worden toegevoegd en gewijzigd met invoervalidatie. |
| Should | Als medewerker wil ik alleen beschikbare voertuigen kunnen reserveren, zodat een voertuig niet dubbel wordt geboekt. | De applicatie blokkeert overlappende reserveringen voor hetzelfde voertuig. |
| Should | Als medewerker wil ik een reservering kunnen aanpassen of verwijderen, zodat wijzigingen in de planning verwerkt kunnen worden. | Gegevens van een reservering kunnen worden gewijzigd of verwijderd. |
| Should | Als medewerker wil ik duidelijke foutmeldingen zien, zodat ik invoerfouten zelf kan herstellen. | Foutmeldingen leggen per veld uit welke invoer ongeldig is. |

## Could haves

| Prioriteit | User story | Acceptatiecriteria |
| --- | --- | --- |
| Could | Als medewerker wil ik reserveringen kunnen filteren op betaalstatus, zodat ik snel openstaande betalingen vind. | Er is een filter voor betaald en openstaand. |
| Could | Als medewerker wil ik zoeken op kenteken of klantnaam, zodat ik gegevens sneller vind. | De relevante overzichten hebben een zoekveld. |
| Could | Als medewerker wil ik een dashboard met kerncijfers zien, zodat ik snel zicht heb op de planning. | Het dashboard toont aantallen voertuigen, actieve reserveringen en openstaande betalingen. |
| Could | Als medewerker wil ik schadehistorie per voertuig bijhouden, zodat ik terugkerende schade kan herkennen. | Schademeldingen krijgen datum, omschrijving en voertuigkoppeling. |

## Niet in deze eerste versie

- Inloggen en rollen voor verschillende medewerkers
- Online betalingen
- E-mailbevestigingen naar klanten
- Automatische routeplanning
