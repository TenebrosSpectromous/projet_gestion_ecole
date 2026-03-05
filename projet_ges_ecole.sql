-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : jeu. 05 mars 2026 à 12:32
-- Version du serveur : 8.3.0
-- Version de PHP : 8.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `projet_ges_ecole`
--

-- --------------------------------------------------------

--
-- Structure de la table `absence`
--

DROP TABLE IF EXISTS `absence`;
CREATE TABLE IF NOT EXISTS `absence` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idEtudiant` int NOT NULL,
  `idProfesseur` int NOT NULL,
  `Motif` varchar(50) NOT NULL,
  `DateAbsence` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_etdiant_absence` (`idEtudiant`),
  KEY `fk_professeur_absence` (`idProfesseur`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `absence`
--

INSERT INTO `absence` (`id`, `idEtudiant`, `idProfesseur`, `Motif`, `DateAbsence`) VALUES
(1, 1, 0, 'maladie', '2026-03-03'),
(2, 2, 0, 'non recevable', '2026-02-15'),
(3, 3, 0, 'permis', '2026-01-15'),
(4, 5, 0, 'non recevable', '2025-12-15'),
(8, 1, 13, 'inconnu', '2026-03-03');

-- --------------------------------------------------------

--
-- Structure de la table `absences_professeurs`
--

DROP TABLE IF EXISTS `absences_professeurs`;
CREATE TABLE IF NOT EXISTS `absences_professeurs` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idProfesseur` int NOT NULL,
  `DateDebut` date NOT NULL,
  `DateFin` date NOT NULL,
  `Motif` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `idProfesseur` (`idProfesseur`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `absences_professeurs`
--

INSERT INTO `absences_professeurs` (`id`, `idProfesseur`, `DateDebut`, `DateFin`, `Motif`) VALUES
(1, 1, '2026-03-02', '2026-03-04', 'inconnu');

-- --------------------------------------------------------

--
-- Structure de la table `administration`
--

DROP TABLE IF EXISTS `administration`;
CREATE TABLE IF NOT EXISTS `administration` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Nom` varchar(50) NOT NULL,
  `Prenom` varchar(50) NOT NULL,
  `Identifiant` varchar(50) NOT NULL,
  `Mdp` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `administration`
--

INSERT INTO `administration` (`id`, `Nom`, `Prenom`, `Identifiant`, `Mdp`) VALUES
(1, 'Dupont', 'Jean', 'admin', 'jdupont1');

-- --------------------------------------------------------

--
-- Structure de la table `classe`
--

DROP TABLE IF EXISTS `classe`;
CREATE TABLE IF NOT EXISTS `classe` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Libelle` varchar(50) NOT NULL,
  `Niveau` varchar(10) NOT NULL,
  `idProfesseur` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_professeur_classe` (`idProfesseur`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `classe`
--

INSERT INTO `classe` (`id`, `Libelle`, `Niveau`, `idProfesseur`) VALUES
(1, '6 ÈME', '6', 1),
(2, '5 ÈME', '5', 2),
(3, '4 ÈME', '4', 3),
(4, '3 ÈME', '3', 4);

-- --------------------------------------------------------

--
-- Structure de la table `emploi_du_temps`
--

DROP TABLE IF EXISTS `emploi_du_temps`;
CREATE TABLE IF NOT EXISTS `emploi_du_temps` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idClasse` int NOT NULL,
  `idProfesseur` int NOT NULL,
  `idMatiere` int NOT NULL,
  `Jour` enum('Lundi','Mardi','Mercredi','Jeudi','Vendredi') NOT NULL,
  `HeureDebut` time NOT NULL,
  `HeureFin` time NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idProfesseur` (`idProfesseur`),
  KEY `idMatiere` (`idMatiere`)
) ENGINE=MyISAM AUTO_INCREMENT=141 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `emploi_du_temps`
--

INSERT INTO `emploi_du_temps` (`id`, `idClasse`, `idProfesseur`, `idMatiere`, `Jour`, `HeureDebut`, `HeureFin`) VALUES
(1, 1, 3, 3, 'Lundi', '08:00:00', '09:00:00'),
(2, 2, 2, 2, 'Lundi', '08:00:00', '09:00:00'),
(3, 3, 1, 1, 'Lundi', '08:00:00', '09:00:00'),
(4, 4, 4, 4, 'Lundi', '08:00:00', '09:00:00'),
(5, 1, 2, 2, 'Lundi', '09:00:00', '10:00:00'),
(6, 2, 3, 3, 'Lundi', '09:00:00', '10:00:00'),
(7, 3, 4, 4, 'Lundi', '09:00:00', '10:00:00'),
(8, 4, 1, 1, 'Lundi', '09:00:00', '10:00:00'),
(9, 1, 5, 5, 'Lundi', '10:00:00', '11:00:00'),
(10, 2, 6, 6, 'Lundi', '10:00:00', '11:00:00'),
(11, 3, 7, 7, 'Lundi', '10:00:00', '11:00:00'),
(12, 4, 8, 8, 'Lundi', '10:00:00', '11:00:00'),
(13, 1, 6, 6, 'Lundi', '11:00:00', '12:00:00'),
(14, 2, 5, 5, 'Lundi', '11:00:00', '12:00:00'),
(15, 3, 8, 8, 'Lundi', '11:00:00', '12:00:00'),
(16, 4, 7, 7, 'Lundi', '11:00:00', '12:00:00'),
(17, 1, 8, 8, 'Lundi', '13:00:00', '14:00:00'),
(18, 2, 7, 7, 'Lundi', '13:00:00', '14:00:00'),
(19, 3, 5, 5, 'Lundi', '13:00:00', '14:00:00'),
(20, 4, 6, 6, 'Lundi', '13:00:00', '14:00:00'),
(21, 1, 11, 11, 'Lundi', '14:00:00', '15:00:00'),
(22, 2, 12, 12, 'Lundi', '14:00:00', '15:00:00'),
(23, 3, 11, 11, 'Lundi', '14:00:00', '15:00:00'),
(24, 4, 12, 12, 'Lundi', '14:00:00', '15:00:00'),
(25, 1, 12, 12, 'Lundi', '15:00:00', '16:00:00'),
(26, 2, 11, 11, 'Lundi', '15:00:00', '16:00:00'),
(27, 3, 12, 12, 'Lundi', '15:00:00', '16:00:00'),
(28, 4, 11, 11, 'Lundi', '15:00:00', '16:00:00'),
(29, 1, 1, 1, 'Mardi', '08:00:00', '09:00:00'),
(30, 2, 4, 4, 'Mardi', '08:00:00', '09:00:00'),
(31, 3, 3, 3, 'Mardi', '08:00:00', '09:00:00'),
(32, 4, 2, 2, 'Mardi', '08:00:00', '09:00:00'),
(33, 1, 4, 4, 'Mardi', '09:00:00', '10:00:00'),
(34, 2, 1, 1, 'Mardi', '09:00:00', '10:00:00'),
(35, 3, 2, 2, 'Mardi', '09:00:00', '10:00:00'),
(36, 4, 3, 3, 'Mardi', '09:00:00', '10:00:00'),
(37, 1, 7, 7, 'Mardi', '10:00:00', '11:00:00'),
(38, 2, 8, 8, 'Mardi', '10:00:00', '11:00:00'),
(39, 3, 6, 6, 'Mardi', '10:00:00', '11:00:00'),
(40, 4, 5, 5, 'Mardi', '10:00:00', '11:00:00'),
(41, 1, 8, 8, 'Mardi', '11:00:00', '12:00:00'),
(42, 2, 7, 7, 'Mardi', '11:00:00', '12:00:00'),
(43, 3, 5, 5, 'Mardi', '11:00:00', '12:00:00'),
(44, 4, 6, 6, 'Mardi', '11:00:00', '12:00:00'),
(45, 1, 9, 9, 'Mardi', '13:00:00', '14:00:00'),
(46, 2, 10, 10, 'Mardi', '13:00:00', '14:00:00'),
(47, 3, 9, 9, 'Mardi', '13:00:00', '14:00:00'),
(48, 4, 10, 10, 'Mardi', '13:00:00', '14:00:00'),
(49, 1, 11, 11, 'Mardi', '14:00:00', '15:00:00'),
(50, 2, 12, 12, 'Mardi', '14:00:00', '15:00:00'),
(51, 3, 12, 12, 'Mardi', '14:00:00', '15:00:00'),
(52, 4, 11, 11, 'Mardi', '14:00:00', '15:00:00'),
(53, 1, 3, 3, 'Mardi', '15:00:00', '16:00:00'),
(54, 2, 2, 2, 'Mardi', '15:00:00', '16:00:00'),
(55, 3, 1, 1, 'Mardi', '15:00:00', '16:00:00'),
(56, 4, 4, 4, 'Mardi', '15:00:00', '16:00:00'),
(57, 1, 2, 2, 'Mercredi', '08:00:00', '09:00:00'),
(58, 2, 3, 3, 'Mercredi', '08:00:00', '09:00:00'),
(59, 3, 4, 4, 'Mercredi', '08:00:00', '09:00:00'),
(60, 4, 1, 1, 'Mercredi', '08:00:00', '09:00:00'),
(61, 1, 5, 5, 'Mercredi', '09:00:00', '10:00:00'),
(62, 2, 6, 6, 'Mercredi', '09:00:00', '10:00:00'),
(63, 3, 3, 3, 'Mercredi', '09:00:00', '10:00:00'),
(64, 4, 2, 2, 'Mercredi', '09:00:00', '10:00:00'),
(65, 1, 6, 6, 'Mercredi', '10:00:00', '11:00:00'),
(66, 2, 5, 5, 'Mercredi', '10:00:00', '11:00:00'),
(67, 3, 1, 1, 'Mercredi', '10:00:00', '11:00:00'),
(68, 4, 4, 4, 'Mercredi', '10:00:00', '11:00:00'),
(69, 1, 4, 4, 'Mercredi', '11:00:00', '12:00:00'),
(70, 2, 1, 1, 'Mercredi', '11:00:00', '12:00:00'),
(71, 3, 2, 2, 'Mercredi', '11:00:00', '12:00:00'),
(72, 4, 3, 3, 'Mercredi', '11:00:00', '12:00:00'),
(73, 1, 7, 7, 'Mercredi', '13:00:00', '14:00:00'),
(74, 2, 8, 8, 'Mercredi', '13:00:00', '14:00:00'),
(75, 3, 11, 11, 'Mercredi', '13:00:00', '14:00:00'),
(76, 4, 12, 12, 'Mercredi', '13:00:00', '14:00:00'),
(77, 1, 8, 8, 'Mercredi', '14:00:00', '15:00:00'),
(78, 2, 7, 7, 'Mercredi', '14:00:00', '15:00:00'),
(79, 3, 12, 12, 'Mercredi', '14:00:00', '15:00:00'),
(80, 4, 11, 11, 'Mercredi', '14:00:00', '15:00:00'),
(81, 1, 11, 11, 'Mercredi', '15:00:00', '16:00:00'),
(82, 2, 12, 12, 'Mercredi', '15:00:00', '16:00:00'),
(83, 3, 8, 8, 'Mercredi', '15:00:00', '16:00:00'),
(84, 4, 7, 7, 'Mercredi', '15:00:00', '16:00:00'),
(85, 1, 4, 4, 'Jeudi', '08:00:00', '09:00:00'),
(86, 2, 1, 1, 'Jeudi', '08:00:00', '09:00:00'),
(87, 3, 2, 2, 'Jeudi', '08:00:00', '09:00:00'),
(88, 4, 3, 3, 'Jeudi', '08:00:00', '09:00:00'),
(89, 1, 1, 1, 'Jeudi', '09:00:00', '10:00:00'),
(90, 2, 4, 4, 'Jeudi', '09:00:00', '10:00:00'),
(91, 3, 3, 3, 'Jeudi', '09:00:00', '10:00:00'),
(92, 4, 2, 2, 'Jeudi', '09:00:00', '10:00:00'),
(93, 1, 3, 3, 'Jeudi', '10:00:00', '11:00:00'),
(94, 2, 2, 2, 'Jeudi', '10:00:00', '11:00:00'),
(95, 3, 6, 6, 'Jeudi', '10:00:00', '11:00:00'),
(96, 4, 5, 5, 'Jeudi', '10:00:00', '11:00:00'),
(97, 1, 2, 2, 'Jeudi', '11:00:00', '12:00:00'),
(98, 2, 3, 3, 'Jeudi', '11:00:00', '12:00:00'),
(99, 3, 5, 5, 'Jeudi', '11:00:00', '12:00:00'),
(100, 4, 6, 6, 'Jeudi', '11:00:00', '12:00:00'),
(101, 1, 10, 10, 'Jeudi', '13:00:00', '14:00:00'),
(102, 2, 9, 9, 'Jeudi', '13:00:00', '14:00:00'),
(103, 3, 10, 10, 'Jeudi', '13:00:00', '14:00:00'),
(104, 4, 9, 9, 'Jeudi', '13:00:00', '14:00:00'),
(105, 1, 5, 5, 'Jeudi', '14:00:00', '15:00:00'),
(106, 2, 6, 6, 'Jeudi', '14:00:00', '15:00:00'),
(107, 3, 7, 7, 'Jeudi', '14:00:00', '15:00:00'),
(108, 4, 8, 8, 'Jeudi', '14:00:00', '15:00:00'),
(109, 1, 6, 6, 'Jeudi', '15:00:00', '16:00:00'),
(110, 2, 5, 5, 'Jeudi', '15:00:00', '16:00:00'),
(111, 3, 8, 8, 'Jeudi', '15:00:00', '16:00:00'),
(112, 4, 7, 7, 'Jeudi', '15:00:00', '16:00:00'),
(113, 1, 7, 7, 'Vendredi', '08:00:00', '09:00:00'),
(114, 2, 8, 8, 'Vendredi', '08:00:00', '09:00:00'),
(115, 3, 9, 9, 'Vendredi', '08:00:00', '09:00:00'),
(116, 4, 10, 10, 'Vendredi', '08:00:00', '09:00:00'),
(117, 1, 8, 8, 'Vendredi', '09:00:00', '10:00:00'),
(118, 2, 7, 7, 'Vendredi', '09:00:00', '10:00:00'),
(119, 3, 10, 10, 'Vendredi', '09:00:00', '10:00:00'),
(120, 4, 9, 9, 'Vendredi', '09:00:00', '10:00:00'),
(121, 1, 9, 9, 'Vendredi', '10:00:00', '11:00:00'),
(122, 2, 10, 10, 'Vendredi', '10:00:00', '11:00:00'),
(123, 3, 11, 11, 'Vendredi', '10:00:00', '11:00:00'),
(124, 4, 12, 12, 'Vendredi', '10:00:00', '11:00:00'),
(125, 1, 10, 10, 'Vendredi', '11:00:00', '12:00:00'),
(126, 2, 9, 9, 'Vendredi', '11:00:00', '12:00:00'),
(127, 3, 12, 12, 'Vendredi', '11:00:00', '12:00:00'),
(128, 4, 11, 11, 'Vendredi', '11:00:00', '12:00:00'),
(129, 1, 12, 12, 'Vendredi', '13:00:00', '14:00:00'),
(130, 2, 11, 11, 'Vendredi', '13:00:00', '14:00:00'),
(131, 3, 4, 4, 'Vendredi', '13:00:00', '14:00:00'),
(132, 4, 1, 1, 'Vendredi', '13:00:00', '14:00:00'),
(133, 1, 11, 11, 'Vendredi', '14:00:00', '15:00:00'),
(134, 2, 12, 12, 'Vendredi', '14:00:00', '15:00:00'),
(135, 3, 1, 1, 'Vendredi', '14:00:00', '15:00:00'),
(136, 4, 4, 4, 'Vendredi', '14:00:00', '15:00:00'),
(137, 1, 1, 1, 'Vendredi', '15:00:00', '16:00:00'),
(138, 2, 4, 4, 'Vendredi', '15:00:00', '16:00:00'),
(139, 3, 6, 6, 'Vendredi', '15:00:00', '16:00:00'),
(140, 4, 5, 5, 'Vendredi', '15:00:00', '16:00:00');

-- --------------------------------------------------------

--
-- Structure de la table `etudiant`
--

DROP TABLE IF EXISTS `etudiant`;
CREATE TABLE IF NOT EXISTS `etudiant` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Nom` varchar(50) NOT NULL,
  `Prenom` varchar(50) NOT NULL,
  `DateNaissance` date NOT NULL,
  `idClasse` int NOT NULL,
  `Telephone` int NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Moyenne` double NOT NULL,
  `Identifiant` varchar(50) NOT NULL,
  `Mdp` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_etudiant_classe` (`idClasse`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `etudiant`
--

INSERT INTO `etudiant` (`id`, `Nom`, `Prenom`, `DateNaissance`, `idClasse`, `Telephone`, `Email`, `Moyenne`, `Identifiant`, `Mdp`) VALUES
(1, 'Martin', 'Lucas', '2012-03-15', 1, 700000001, 'lucas.martin@ecole.fr', 0, 'lmartin6', 'Eleve6eme2024'),
(2, 'Durand', 'Emma', '2011-07-22', 2, 700000002, 'emma.durand@ecole.fr', 0, 'edurand5', 'Eleve5eme2024'),
(3, 'Petit', 'Nathan', '2010-11-09', 3, 700000003, 'nathan.petit@ecole.fr', 0, 'npetit4', 'Eleve4eme2024'),
(4, 'Moreau', 'Chloe', '2009-05-18', 4, 700000004, 'chloe.moreau@ecole.fr', 0, 'cmoreau3', 'Eleve3eme2024'),
(5, 'Bernard', 'Sophie', '2011-03-22', 2, 700000005, 'sophie.bernard@ecole.fr', 0, 'sbernard5', 'Eleve5eme2024'),
(6, 'Leroy', 'Tom', '2010-06-14', 3, 700000006, 'tom.leroy@ecole.fr', 0, 'tleroy4', 'Eleve4eme2024'),
(7, 'Simon', 'Léa', '2009-09-30', 4, 700000007, 'lea.simon@ecole.fr', 0, 'lsimon3', 'Eleve3eme2024'),
(8, 'Dupont', 'Hugo', '2012-11-05', 1, 700000008, 'hugo.dupont@ecole.fr', 0, 'hdupont6', 'Eleve6eme2024');

-- --------------------------------------------------------

--
-- Structure de la table `matiere`
--

DROP TABLE IF EXISTS `matiere`;
CREATE TABLE IF NOT EXISTS `matiere` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Libelle` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `matiere`
--

INSERT INTO `matiere` (`id`, `Libelle`) VALUES
(1, 'Sport'),
(2, 'Français'),
(3, 'Mathématique'),
(4, 'SVT'),
(5, 'Physique-Chimie'),
(6, 'Technologie'),
(7, 'Musique'),
(8, 'Anglais'),
(9, 'Espagnol'),
(10, 'Allemand'),
(11, 'Histoire-Géographie-EMC'),
(12, 'Arts-Plastique');

-- --------------------------------------------------------

--
-- Structure de la table `note`
--

DROP TABLE IF EXISTS `note`;
CREATE TABLE IF NOT EXISTS `note` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idEtudiant` int NOT NULL,
  `idProfesseur` int NOT NULL,
  `idMatiere` int NOT NULL,
  `Note` double NOT NULL,
  `Coefficient` double NOT NULL,
  `DateEval` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_etudiant_note` (`idEtudiant`),
  KEY `fk_professeur_note` (`idProfesseur`),
  KEY `fk_matiere_note` (`idMatiere`)
) ENGINE=MyISAM AUTO_INCREMENT=92 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `note`
--

INSERT INTO `note` (`id`, `idEtudiant`, `idProfesseur`, `idMatiere`, `Note`, `Coefficient`, `DateEval`) VALUES
(6, 3, 1, 1, 16, 1, '2025-09-15'),
(5, 2, 1, 1, 12, 1, '2025-09-15'),
(4, 1, 1, 1, 14, 1, '2025-09-15'),
(7, 4, 1, 1, 11, 1, '2025-09-15'),
(8, 5, 1, 1, 15, 1, '2025-09-15'),
(9, 6, 1, 1, 13, 1, '2025-09-15'),
(10, 7, 1, 1, 9, 1, '2025-09-15'),
(11, 8, 1, 1, 17, 1, '2025-09-15'),
(12, 1, 2, 2, 13, 1, '2025-09-16'),
(13, 2, 2, 2, 15, 1, '2025-09-16'),
(14, 3, 2, 2, 11, 1, '2025-09-16'),
(15, 4, 2, 2, 14, 1, '2025-09-16'),
(16, 5, 2, 2, 12, 1, '2025-09-16'),
(17, 6, 2, 2, 16, 1, '2025-09-16'),
(18, 7, 2, 2, 10, 1, '2025-09-16'),
(19, 8, 2, 2, 18, 1, '2025-09-16'),
(20, 1, 3, 3, 10, 1, '2025-09-17'),
(21, 2, 3, 3, 14, 1, '2025-09-17'),
(22, 3, 3, 3, 17, 1, '2025-09-17'),
(23, 4, 3, 3, 8, 1, '2025-09-17'),
(24, 5, 3, 3, 13, 1, '2025-09-17'),
(25, 6, 3, 3, 11, 1, '2025-09-17'),
(26, 7, 3, 3, 15, 1, '2025-09-17'),
(27, 8, 3, 3, 12, 1, '2025-09-17'),
(28, 1, 4, 4, 12, 1, '2025-09-18'),
(29, 2, 4, 4, 9, 1, '2025-09-18'),
(30, 3, 4, 4, 14, 1, '2025-09-18'),
(31, 4, 4, 4, 16, 1, '2025-09-18'),
(32, 5, 4, 4, 11, 1, '2025-09-18'),
(33, 6, 4, 4, 13, 1, '2025-09-18'),
(34, 7, 4, 4, 8, 1, '2025-09-18'),
(35, 8, 4, 4, 15, 1, '2025-09-18'),
(36, 1, 5, 5, 15, 1, '2025-09-19'),
(37, 2, 5, 5, 11, 1, '2025-09-19'),
(38, 3, 5, 5, 13, 1, '2025-09-19'),
(39, 4, 5, 5, 9, 1, '2025-09-19'),
(40, 5, 5, 5, 17, 1, '2025-09-19'),
(41, 6, 5, 5, 12, 1, '2025-09-19'),
(42, 7, 5, 5, 14, 1, '2025-09-19'),
(43, 8, 5, 5, 10, 1, '2025-09-19'),
(44, 1, 6, 6, 11, 1, '2025-09-20'),
(45, 2, 6, 6, 13, 1, '2025-09-20'),
(46, 3, 6, 6, 15, 1, '2025-09-20'),
(47, 4, 6, 6, 10, 1, '2025-09-20'),
(48, 5, 6, 6, 14, 1, '2025-09-20'),
(49, 6, 6, 6, 8, 1, '2025-09-20'),
(50, 7, 6, 6, 16, 1, '2025-09-20'),
(51, 8, 6, 6, 12, 1, '2025-09-20'),
(52, 1, 7, 7, 16, 1, '2025-09-21'),
(53, 2, 7, 7, 12, 1, '2025-09-21'),
(54, 3, 7, 7, 10, 1, '2025-09-21'),
(55, 4, 7, 7, 14, 1, '2025-09-21'),
(56, 5, 7, 7, 9, 1, '2025-09-21'),
(57, 6, 7, 7, 15, 1, '2025-09-21'),
(58, 7, 7, 7, 13, 1, '2025-09-21'),
(59, 8, 7, 7, 11, 1, '2025-09-21'),
(60, 1, 8, 8, 14, 1, '2025-09-22'),
(61, 2, 8, 8, 16, 1, '2025-09-22'),
(62, 3, 8, 8, 12, 1, '2025-09-22'),
(63, 4, 8, 8, 10, 1, '2025-09-22'),
(64, 5, 8, 8, 15, 1, '2025-09-22'),
(65, 6, 8, 8, 13, 1, '2025-09-22'),
(66, 7, 8, 8, 11, 1, '2025-09-22'),
(67, 8, 8, 8, 17, 1, '2025-09-22'),
(68, 1, 9, 9, 13, 1, '2025-09-23'),
(69, 2, 9, 9, 15, 1, '2025-09-23'),
(70, 3, 9, 9, 11, 1, '2025-09-23'),
(71, 4, 9, 9, 14, 1, '2025-09-23'),
(72, 5, 10, 10, 12, 1, '2025-09-24'),
(73, 6, 10, 10, 10, 1, '2025-09-24'),
(74, 7, 10, 10, 16, 1, '2025-09-24'),
(75, 8, 10, 10, 9, 1, '2025-09-24'),
(76, 1, 11, 11, 13, 1, '2025-09-25'),
(77, 2, 11, 11, 15, 1, '2025-09-25'),
(78, 3, 11, 11, 9, 1, '2025-09-25'),
(79, 4, 11, 11, 12, 1, '2025-09-25'),
(80, 5, 11, 11, 16, 1, '2025-09-25'),
(81, 6, 11, 11, 11, 1, '2025-09-25'),
(82, 7, 11, 11, 14, 1, '2025-09-25'),
(83, 8, 11, 11, 10, 1, '2025-09-25'),
(84, 1, 12, 12, 15, 1, '2025-09-26'),
(85, 2, 12, 12, 11, 1, '2025-09-26'),
(86, 3, 12, 12, 13, 1, '2025-09-26'),
(87, 4, 12, 12, 17, 1, '2025-09-26'),
(88, 5, 12, 12, 9, 1, '2025-09-26'),
(89, 6, 12, 12, 14, 1, '2025-09-26'),
(90, 7, 12, 12, 12, 1, '2025-09-26'),
(91, 8, 12, 12, 16, 1, '2025-09-26');

-- --------------------------------------------------------

--
-- Structure de la table `professeur`
--

DROP TABLE IF EXISTS `professeur`;
CREATE TABLE IF NOT EXISTS `professeur` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Nom` varchar(50) NOT NULL,
  `Prenom` varchar(50) NOT NULL,
  `idMatiere` int NOT NULL,
  `Telephone` int NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Identifiant` varchar(50) NOT NULL,
  `Mdp` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_matiere_prof` (`idMatiere`)
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `professeur`
--

INSERT INTO `professeur` (`id`, `Nom`, `Prenom`, `idMatiere`, `Telephone`, `Email`, `Identifiant`, `Mdp`) VALUES
(1, 'Leroy', 'Thomas', 1, 600000001, 'thomas.leroy@ecole.fr', 'tleroy', 'ProfSport2024'),
(2, 'Martin', 'Claire', 2, 600000002, 'claire.martin@ecole.fr', 'cmartin', 'ProfFrancais2024'),
(3, 'Dubois', 'Julien', 3, 600000003, 'julien.dubois@ecole.fr', 'jdubois', 'ProfMath2024'),
(4, 'Moreau', 'Sophie', 4, 600000004, 'sophie.moreau@ecole.fr', 'smoreau', 'ProfSVT2024'),
(5, 'Bernard', 'Lucas', 5, 600000005, 'lucas.bernard@ecole.fr', 'lbernard', 'ProfPhysique2024'),
(6, 'Garcia', 'Nicolas', 6, 600000006, 'nicolas.garcia@ecole.fr', 'ngarcia', 'ProfTechno2024'),
(7, 'Petit', 'Laura', 7, 600000007, 'laura.petit@ecole.fr', 'lpetit', 'ProfMusique2024'),
(8, 'Roux', 'David', 8, 600000008, 'david.roux@ecole.fr', 'droux', 'ProfAnglais2024'),
(9, 'Lopez', 'Maria', 9, 600000009, 'maria.lopez@ecole.fr', 'mlopez', 'ProfEspagnol2024'),
(10, 'Schmidt', 'Anna', 10, 600000010, 'anna.schmidt@ecole.fr', 'aschmidt', 'ProfAllemand2024'),
(11, 'Faure', 'Pierre', 11, 600000011, 'pierre.faure@ecole.fr', 'pfaure', 'ProfHistoire2024'),
(12, 'Blanc', 'Camille', 12, 600000012, 'camille.blanc@ecole.fr', 'cblanc', 'ProfArt2024');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
