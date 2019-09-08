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
-- Table structure for table `storeproduct`
--

DROP TABLE IF EXISTS `storeproduct`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `storeproduct` (
  `product_ID` int(10) NOT NULL AUTO_INCREMENT,
  `itemCode` int(10) NOT NULL,
  `titleID` int(10) NOT NULL,
  `product_name` varchar(25) DEFAULT NULL,
  `image` varchar(255) DEFAULT NULL,
  `description` varchar(1000) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `price` float DEFAULT NULL,
  PRIMARY KEY (`product_ID`),
  KEY `fk_ItemCode` (`itemCode`),
  KEY `fk_Title` (`titleID`),
  CONSTRAINT `fk_ItemCode` FOREIGN KEY (`itemCode`) REFERENCES `inventory` (`itemCode`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_Title` FOREIGN KEY (`titleID`) REFERENCES `title` (`titleID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `storeproduct`
--

LOCK TABLES `storeproduct` WRITE;
/*!40000 ALTER TABLE `storeproduct` DISABLE KEYS */;
INSERT INTO `storeproduct` VALUES (1,12,1,'Mega Mass','~/Content/image/s1.PNG','Lorem ipsum esum',3,14000),(3,32,3,'Jersey','~/Content/image/n3.jpg','jersey',4,1200),(4,33,8,'Dumbbell','~/Content/image/e1.jpg','dumbell',2,6000);
/*!40000 ALTER TABLE `storeproduct` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-09-08 19:28:15
