# Sprint 1 — Principes SOLID

## Exercices

### Exercice 1 — SRP (Single Responsibility Principle)

#### 1.1 Melange de niveaux de responsabilite

Pour cet exercice, j’ai séparé les trois préoccupations en trois dossiers distincts, en m’appuyant sur des interfaces pour découpler les dépendances :

Domain : contient les règles métier, indépendantes de toute implémentation technique
Infrastructure : gère l’accès aux données et les aspects techniques (logging, persistance, etc.) en implémentant les interfaces
Application : orchestre le workflow et les cas d’usage, en s’appuyant sur les interfaces définies dans le domaine

#### 1.2 Melange de niveaux d'abstraction

Pour répondre à ce problème, nous avons mis en place un service de cache chargé de gérer la mise en cache. Ce service encapsule le service de check-in existant et en étend le comportement en y ajoutant une couche de cache.

#### 1.3 Plusieurs acteurs, une seule classe (1 point)

Correction apportée :

Chaque responsabilité a été isolée selon l’acteur concerné :

Le comptable est désormais responsable du calcul via un service dédié (Accountant) qui implémente Calculate() et GenerateInvoiceLine()
Le réceptionniste conserve la logique d’annulation via l’interface ICancellable, déjà implémentée
La gouvernante voit la gestion du linge déplacée dans un HousekeepingService avec GetLinenChangeDays()

La classe Reservation est ainsi recentrée sur son rôle métier principal, tandis que chaque acteur manipule ses propres règles via des services dédiés.

---

### Exercice 2 — OCP (Open/Closed Principle)

- `Events/ReservationEventDispatcher.cs` — quel pattern ? Observer
- `Interfaces/IPriceCalculator.cs` + `SeasonalSurchargeDecorator.cs` — quel pattern ? Decorator
- `Interfaces/ICleaningPolicy.cs` + implementations — quel pattern ? Le strategy pattern et permet de créer de nouvelle strategie de nettoyage

#### 2.2 Corriger l'exemple mal fait

Pour cet exemple, j’ai mis en place un pattern Factory permettant de créer dynamiquement la politique à appliquer lors de l’ajout d’une réservation.

---

### Exercice 3 — LSP (Liskov Substitution Principle)

Correction apporté 

création des deux interfaces

#### 3.2 Violation semantique

Correction apporté 

En injectant IRoomRepository, le service de cache délègue désormais l’appel à GetAvailableRooms(dates) au repository sous-jacent afin de récupérer des données à jour.
La méthode Save, quant à elle, invalide explicitement le cache pour éviter toute incohérence entre les données persistées et celles mises en cache.

---

### Exercice 4 — ISP (Interface Segregation Principle)

Repositories/IReservationRepository.cs -> Créer deux interfaces IReservationRepository, IReservationBilling

Services/InvoiceGenerator.cs -> Création d'un modèle InvoiceInformationReservation

Interfaces/INotificationService.cs -> Création de 4 interfaces INotificationEmail, SMS, Push, Slack

---

// PAS FAIT CAR Booking Service n'est pas utilisé
### Exercice 5 — DIP (Dependency Inversion Principle)

**Rappel** : Les modules de haut niveau ne doivent pas dependre des modules de bas niveau.
Les deux doivent dependre d'abstractions. **L'interface appartient au consommateur, pas au fournisseur.**

#### 5.1 Service metier couple a l'infrastructure

Fichier : `Services/BookingService.cs`

`BookingService` instancie directement `InMemoryReservationStore` et `FileLogger`.
Impossible de changer le stockage ou le logging sans modifier cette classe.

**A faire** :
1. Definir `IReservationRepository` et `ILogger` **dans le meme namespace que le service metier**
2. Les implementations d'infrastructure implementent ces interfaces
3. `BookingService` recoit les abstractions par constructeur


// PAS FAIT CAR J'AI SUPPRIMER LE EMAIL SENDER par les notifications
#### 5.2 Module metier couple au module technique

Fichier : `Services/HousekeepingService.cs`

Le module Housekeeping (metier) depend directement de `EmailSender` (technique).

**A faire** :
1. Definir `ICleaningNotifier` **dans le module Housekeeping/Domain**
2. Creer `EmailCleaningNotifier` comme **Adapter** dans Infrastructure
3. `HousekeepingService` ne connait que `ICleaningNotifier`

Le schema de dependance doit etre :
```
HousekeepingService -> ICleaningNotifier (dans Domain)
                              ^
               EmailCleaningNotifier (dans Infrastructure)
                              |
                         EmailSender (dans Infrastructure)
```

---

### Exercice 6 — Justification ecrite

Le problème identifié était un code en spaghetti, avec des responsabilités mélangées, peu ou pas d’injection de dépendances, un fort couplage et une faible modularité.
La solution appliquée a consisté à introduire des design patterns appropriés et à organiser le code de manière structurée, en séparant clairement les responsabilités et en facilitant l’extensibilité et la maintenabilité.

---
## Livrables

1. Le code refactore dans `src/HotelReservation/` (doit compiler et produire le meme output)
2. Un fichier `JUSTIFICATION.md` avec vos choix

## Rappel

> Les patterns emergent des principes. Ne les appliquez pas mecaniquement.
> Comprenez d'abord le probleme, puis la solution viendra naturellement.
