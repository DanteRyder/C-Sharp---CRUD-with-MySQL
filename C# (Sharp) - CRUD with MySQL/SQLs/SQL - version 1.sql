-- SQL - Version 1

-- Create Database 
CREATE SCHEMA `crud` DEFAULT CHARACTER SET utf8 ;

-- Create Table 
CREATE TABLE `crud`.`user` (
  `id_user` INT(11) NOT NULL AUTO_INCREMENT,
  `name_user` VARCHAR(100) NOT NULL,
  `fone_user` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`id_user`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

-- Select
SELECT * FROM `User`

