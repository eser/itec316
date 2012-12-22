-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Dec 22, 2012 at 11:32 PM
-- Server version: 5.5.24-log
-- PHP Version: 5.3.13

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `kindergarten`
--

-- --------------------------------------------------------

--
-- Table structure for table `accounts`
--

CREATE TABLE IF NOT EXISTS `accounts` (
  `accountid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `accounttype` enum('student','parent','teacher') DEFAULT NULL,
  `email` varchar(255) NOT NULL,
  `fullname` varchar(255) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `address` text,
  `telephone` varchar(255) DEFAULT NULL,
  `birthdate` datetime DEFAULT NULL,
  `level` int(10) unsigned DEFAULT NULL,
  `parentaccountid` int(10) unsigned DEFAULT NULL,
  `classid` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`accountid`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=20 ;

--
-- Dumping data for table `accounts`
--

INSERT INTO `accounts` (`accountid`, `accounttype`, `email`, `fullname`, `username`, `password`, `address`, `telephone`, `birthdate`, `level`, `parentaccountid`, `classid`) VALUES
(2, 'parent', 'parent1@kindergarten.org', 'Parent One', 'parent1', '12345', 'Address One', '555-5555', NULL, 0, NULL, NULL),
(8, 'teacher', 'teacher1@kindergarten.org', 'Teacher One', 'teacher1', '12345', NULL, NULL, NULL, 0, NULL, 1),
(9, 'teacher', 'teacher2@kindergarten.org', 'Teacher Two', 'teacher2', '12345', NULL, NULL, NULL, 0, NULL, 1),
(17, 'student', 'student1@kindergarten.org', 'Student One', 'student1', '12345', NULL, NULL, '2012-12-04 00:00:00', 5, NULL, 1),
(18, 'student', 'student2@kindergarten.org', 'Student Two', 'student2', '12345', NULL, NULL, '2012-12-02 00:00:00', 9000, NULL, 2),
(19, 'student', 'student3@kg.org', 'student Three', 'student3', '12345', NULL, NULL, '2012-11-06 00:00:00', 11, NULL, 2);

-- --------------------------------------------------------

--
-- Table structure for table `classes`
--

CREATE TABLE IF NOT EXISTS `classes` (
  `classid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`classid`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `classes`
--

INSERT INTO `classes` (`classid`, `name`) VALUES
(1, 'Class 1'),
(2, 'Class 2');

-- --------------------------------------------------------

--
-- Table structure for table `gameresults`
--

CREATE TABLE IF NOT EXISTS `gameresults` (
  `gameid` int(10) NOT NULL,
  `stdid` varchar(50) NOT NULL,
  `recorddate` datetime NOT NULL,
  `score` int(11) NOT NULL,
  `level` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `gameresults`
--

INSERT INTO `gameresults` (`gameid`, `stdid`, `recorddate`, `score`, `level`) VALUES
(3, 'student1', '2012-12-23 00:03:55', 10, 0),
(3, 'student1', '2012-12-23 00:19:59', 0, 0),
(3, 'student1', '2012-12-23 00:33:27', 0, 0),
(3, 'student1', '2012-12-23 00:33:36', 20, 0),
(3, 'student1', '2012-12-23 00:36:10', 20, 0),
(3, 'student1', '2012-12-23 00:47:21', 0, 0),
(1, 'student1', '2012-12-23 01:17:05', 11, 3),
(1, 'student1', '2012-12-23 01:23:48', 13, 3),
(1, 'student1', '2012-12-23 01:23:55', 15, 3),
(1, 'student1', '2012-12-23 01:24:13', 15, 3),
(1, 'student1', '2012-12-23 01:24:29', 13, 3),
(1, 'student1', '2012-12-23 01:24:49', 16, 3);

-- --------------------------------------------------------

--
-- Table structure for table `games`
--

CREATE TABLE IF NOT EXISTS `games` (
  `gameid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `gametype` enum('learning','fun') DEFAULT NULL,
  `level` int(10) unsigned NOT NULL,
  PRIMARY KEY (`gameid`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `games`
--

INSERT INTO `games` (`gameid`, `name`, `gametype`, `level`) VALUES
(1, 'Learning 1', 'learning', 1),
(2, 'Learning 2', 'learning', 2),
(3, 'Fun 1', 'fun', 0),
(4, 'Fun 2', 'fun', 0),
(5, 'Fun 3', 'fun', 0);

-- --------------------------------------------------------

--
-- Table structure for table `messages`
--

CREATE TABLE IF NOT EXISTS `messages` (
  `messageid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `senderaccount` int(10) unsigned NOT NULL,
  `receiveraccount` int(10) unsigned NOT NULL,
  `text` text NOT NULL,
  PRIMARY KEY (`messageid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `videos`
--

CREATE TABLE IF NOT EXISTS `videos` (
  `videoid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `datecreated` datetime NOT NULL,
  `createdby` int(10) unsigned NOT NULL,
  `duration` decimal(3,2) NOT NULL,
  `title` varchar(255) NOT NULL,
  PRIMARY KEY (`videoid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
