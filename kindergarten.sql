/*
SQLyog Ultimate v9.20 
MySQL - 5.5.24 : Database - kindergarten
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`kindergarten` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `kindergarten`;

/*Table structure for table `accounts` */

DROP TABLE IF EXISTS `accounts`;

CREATE TABLE `accounts` (
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `accounts` */

insert  into `accounts`(`accountid`,`accounttype`,`email`,`fullname`,`username`,`password`,`address`,`telephone`,`birthdate`,`level`,`parentaccountid`,`classid`) values (1,'teacher','teacher1@kindergarten.org','Teacher One','teacher1','12345',NULL,NULL,NULL,0,NULL,1),(2,'parent','parent1@kindergarten.org','Parent One','parent1','12345','Address One','555-5555',NULL,0,NULL,NULL),(3,'student','student1@kindergarten.org','Student One','student1','12345',NULL,NULL,'2012-12-18 00:56:49',5,2,1);

/*Table structure for table `classes` */

DROP TABLE IF EXISTS `classes`;

CREATE TABLE `classes` (
  `classid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`classid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `classes` */

insert  into `classes`(`classid`,`name`) values (1,'Class 1'),(2,'Class 2');

/*Table structure for table `gameresults` */

DROP TABLE IF EXISTS `gameresults`;

CREATE TABLE `gameresults` (
  `gameid` int(10) unsigned NOT NULL,
  `studentaccountid` int(10) unsigned NOT NULL,
  `recorddate` datetime NOT NULL,
  `score` int(11) NOT NULL,
  PRIMARY KEY (`gameid`,`studentaccountid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `gameresults` */

/*Table structure for table `games` */

DROP TABLE IF EXISTS `games`;

CREATE TABLE `games` (
  `gameid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `gametype` enum('learning','fun') DEFAULT NULL,
  `level` int(10) unsigned NOT NULL,
  PRIMARY KEY (`gameid`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `games` */

insert  into `games`(`gameid`,`name`,`gametype`,`level`) values (1,'Learning 1','learning',1),(2,'Learning 2','learning',2),(3,'Fun 1','fun',0),(4,'Fun 2','fun',0),(5,'Fun 3','fun',0);

/*Table structure for table `messages` */

DROP TABLE IF EXISTS `messages`;

CREATE TABLE `messages` (
  `messageid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `senderaccount` int(10) unsigned NOT NULL,
  `receiveraccount` int(10) unsigned NOT NULL,
  `text` text NOT NULL,
  PRIMARY KEY (`messageid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `messages` */

/*Table structure for table `videos` */

DROP TABLE IF EXISTS `videos`;

CREATE TABLE `videos` (
  `videoid` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `datecreated` datetime NOT NULL,
  `createdby` int(10) unsigned NOT NULL,
  `duration` decimal(3,2) NOT NULL,
  `title` varchar(255) NOT NULL,
  PRIMARY KEY (`videoid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `videos` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
