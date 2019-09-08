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
-- Table structure for table `inventory`
--

DROP TABLE IF EXISTS `inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `inventory` (
  `itemCode` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `quantity` int(11) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `image` varchar(255) DEFAULT NULL,
  `purchased_date` date DEFAULT NULL,
  `supplier` int(11) NOT NULL,
  `catergory` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`itemCode`),
  KEY `sup_ID_idx` (`supplier`),
  CONSTRAINT `sup_ID` FOREIGN KEY (`supplier`) REFERENCES `supplier` (`supplierID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
INSERT INTO `inventory` VALUES (12,'Builder',12,'Supplement',NULL,'2019-06-09',13,'store'),(28,'Treadmill',3,'Accessories',NULL,'2019-08-09',13,'store'),(29,'Treadmill',2,'Accessories',NULL,'2019-08-15',15,'store'),(30,'Gloves',24,'Accessories',NULL,'2018-12-07',15,'store'),(31,'Muscle Builder',12,'Accessories',NULL,'2019-08-02',15,'GYM'),(32,'Jersey',20,'Accessories',NULL,'2019-02-02',15,'store'),(33,'Dumbbell',40,'Equipment',NULL,'2018-10-10',13,'store'),(35,'Muscle Builder',2,'Accessories',NULL,'2019-08-02',15,'Store');
/*!40000 ALTER TABLE `inventory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-09-08 19:28:13
