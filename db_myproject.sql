/*
SQLyog Community v13.1.5  (64 bit)
MySQL - 10.4.14-MariaDB : Database - my_project
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`my_project` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `my_project`;

/*Table structure for table `__efmigrationshistory` */

DROP TABLE IF EXISTS `__efmigrationshistory`;

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `__efmigrationshistory` */

insert  into `__efmigrationshistory`(`MigrationId`,`ProductVersion`) values 
('20220202171254_project1','5.0.13');

/*Table structure for table `tb_employees` */

DROP TABLE IF EXISTS `tb_employees`;

CREATE TABLE `tb_employees` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nama` text DEFAULT NULL,
  `Jk` text DEFAULT NULL,
  `Jabatan` text DEFAULT NULL,
  `Alamat` text DEFAULT NULL,
  `Email` text DEFAULT NULL,
  `NoTelp` text DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_employees` */

insert  into `tb_employees`(`Id`,`Nama`,`Jk`,`Jabatan`,`Alamat`,`Email`,`NoTelp`) values 
(2,'A randy','Laki-Laki','Receptionist','Bandung','Randy@gmail.com','089661058758');

/*Table structure for table `tb_roles` */

DROP TABLE IF EXISTS `tb_roles`;

CREATE TABLE `tb_roles` (
  `Id` varchar(767) NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_roles` */

insert  into `tb_roles`(`Id`,`Name`) values 
('1','Admin');

/*Table structure for table `tb_user` */

DROP TABLE IF EXISTS `tb_user`;

CREATE TABLE `tb_user` (
  `Username` varchar(767) NOT NULL,
  `Password` text DEFAULT NULL,
  `Name` text DEFAULT NULL,
  `Email` text DEFAULT NULL,
  `RolesId` varchar(767) DEFAULT NULL,
  PRIMARY KEY (`Username`),
  KEY `IX_Tb_User_RolesId` (`RolesId`),
  CONSTRAINT `FK_Tb_User_Tb_Roles_RolesId` FOREIGN KEY (`RolesId`) REFERENCES `tb_roles` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tb_user` */

insert  into `tb_user`(`Username`,`Password`,`Name`,`Email`,`RolesId`) values 
('ali','hanafiah','=-0/.','ali1232@gmail.com','1'),
('arie','arie123','arie','arieakbar@gmail.com','1'),
('Buya','reza123','reza','ali123@gmail.com','1');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
