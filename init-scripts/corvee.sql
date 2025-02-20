CREATE DATABASE corvee_app;
USE corvee_app;

CREATE TABLE Gebruiker (
    id INT AUTO_INCREMENT PRIMARY KEY,
    naam VARCHAR(255) NOT NULL,
    avatar_url VARCHAR(512),
    is_admin BOOLEAN NOT NULL DEFAULT FALSE
);

CREATE TABLE Taak (
    id INT AUTO_INCREMENT PRIMARY KEY,
    naam VARCHAR(255) NOT NULL,
    punten INT NOT NULL,
    deadline DATE
);

CREATE TABLE Planning (
    id INT AUTO_INCREMENT PRIMARY KEY,
    gebruiker_id INT NOT NULL,
    taak_id INT NOT NULL,
    uitgevoerd_op DATE,
    notities TEXT,
    fotoUrl VARCHAR(512),
    FOREIGN KEY (gebruiker_id) REFERENCES Gebruiker(id) ON DELETE CASCADE,
    FOREIGN KEY (taak_id) REFERENCES Taak(id) ON DELETE CASCADE
);

-- Voorbeeld data invoegen
INSERT INTO Gebruiker (naam, avatar_url, is_admin) VALUES
('Alice', 'https://example.com/avatar1.jpg', TRUE),
('Bob', 'https://example.com/avatar2.jpg', FALSE),
('Charlie', 'https://example.com/avatar3.jpg', FALSE);

INSERT INTO Taak (naam, punten, deadline) VALUES
('Vaatwasser uitruimen', 5, '2025-03-01'),
('Stofzuigen', 10, '2025-03-02'),
('Afval buiten zetten', 3, '2025-03-03');

INSERT INTO Planning (gebruiker_id, taak_id, uitgevoerd_op, notities, fotoUrl) VALUES
(1, 1, '2025-02-20', 'Netjes gedaan', 'https://example.com/task1.jpg'),
(2, 2, '2025-02-21', 'Extra grondig gestofzuigd', 'https://example.com/task2.jpg'),
(3, 3, '2025-02-22', 'Afvalzak goed dichtgeknoopt', 'https://example.com/task3.jpg');
