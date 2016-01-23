-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Client: 127.0.0.1
-- Généré le: Sam 16 Janvier 2016 à 16:11
-- Version du serveur: 5.5.32
-- Version de PHP: 5.4.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données: `dbassur`
--
CREATE DATABASE IF NOT EXISTS `dbassur` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `dbassur`;

-- --------------------------------------------------------

--
-- Structure de la table `alerte`
--

CREATE TABLE IF NOT EXISTS `alerte` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cin` varchar(8) NOT NULL,
  `date` date NOT NULL,
  `message` text NOT NULL,
  `longtitude` double NOT NULL,
  `latitude` double NOT NULL,
  PRIMARY KEY (`id`),
  KEY `cin` (`cin`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4523 ;

--
-- Contenu de la table `alerte`
--

INSERT INTO `alerte` (`id`, `cin`, `date`, `message`, `longtitude`, `latitude`) VALUES
(4522, '09139517', '2016-01-16', 'je suis en panne j''ai une panne dans le moteur', 45221.2, 45632.1);

-- --------------------------------------------------------

--
-- Structure de la table `clients`
--

CREATE TABLE IF NOT EXISTS `clients` (
  `cin` varchar(8) NOT NULL,
  `nom` varchar(300) NOT NULL,
  `prenom` varchar(300) NOT NULL,
  `email` varchar(300) NOT NULL,
  `tel` varchar(8) NOT NULL,
  PRIMARY KEY (`cin`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `clients`
--

INSERT INTO `clients` (`cin`, `nom`, `prenom`, `email`, `tel`) VALUES
('09139517', 'Lachiheb', 'Oussama', 'oussama.lachiheb@gmail.com', '98751378');

-- --------------------------------------------------------

--
-- Structure de la table `intervention`
--

CREATE TABLE IF NOT EXISTS `intervention` (
  `idalerte` int(11) NOT NULL,
  `idremorqueur` int(11) NOT NULL,
  `etat` varchar(300) NOT NULL,
  PRIMARY KEY (`idalerte`,`idremorqueur`),
  KEY `cck459` (`idremorqueur`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `remorqueur`
--

CREATE TABLE IF NOT EXISTS `remorqueur` (
  `matricule` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(300) NOT NULL,
  `prenom` varchar(300) NOT NULL,
  `telephone` varchar(8) NOT NULL,
  `longtitude` double NOT NULL,
  `latitude` double NOT NULL,
  `password` varchar(300) NOT NULL,
  PRIMARY KEY (`matricule`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1301 ;

--
-- Contenu de la table `remorqueur`
--

INSERT INTO `remorqueur` (`matricule`, `nom`, `prenom`, `telephone`, `longtitude`, `latitude`, `password`) VALUES
(1300, 'Hamroun', 'Mohamed', '55212542', 45211.4, 855421.3, 'kdllemmdlfkld');

--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `alerte`
--
ALTER TABLE `alerte`
  ADD CONSTRAINT `cck45` FOREIGN KEY (`cin`) REFERENCES `clients` (`cin`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `intervention`
--
ALTER TABLE `intervention`
  ADD CONSTRAINT `cck459` FOREIGN KEY (`idremorqueur`) REFERENCES `remorqueur` (`matricule`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `cck458` FOREIGN KEY (`idalerte`) REFERENCES `alerte` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
