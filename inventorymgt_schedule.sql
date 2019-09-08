-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: localhost    Database: inventorymgt
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `schedule`
--

DROP TABLE IF EXISTS `schedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `schedule` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(10) DEFAULT NULL,
  `Gender` varchar(10) DEFAULT NULL,
  `Category` varchar(50) DEFAULT NULL,
  `Level` varchar(45) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `Days` int(11) DEFAULT NULL,
  `Image` varchar(200) DEFAULT NULL,
  `Morning_Trainer` varchar(45) DEFAULT NULL,
  `Evening_Trainer` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=60 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schedule`
--

LOCK TABLES `schedule` WRITE;
/*!40000 ALTER TABLE `schedule` DISABLE KEYS */;
INSERT INTO `schedule` VALUES (49,'M1010','Male','Muscle_Gain','Beginner','This is the Basic Schedule',45,'~/Content/Images/Beginner193741362.JPG','Ross Taylor','Niro'),(51,'M1020','Male','Muscle_Gain','Intermediate','This is muscle gain intermediate schedule.',53,'~/Content/Images/Intermediate193959976.JPG','Alex','Joseph'),(52,'M3040','Male','Weight_loss','Professional','This is Weight loss.',55,'~/Content/Images/Professional194123072.JPG','Joshua','Kevin'),(53,'M2010','Male','Cardio','Beginner','This is Cardio.',45,'~/Content/Images/beginner194326295.JPG','Rogers','Manchester'),(54,'F3030','Female','Weight_loss','Advance','This is Female weight loss',50,'~/Content/Images/Advance194524459.JPG','Lucy','Alfred');
/*!40000 ALTER TABLE `schedule` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-09-08 19:28:09
