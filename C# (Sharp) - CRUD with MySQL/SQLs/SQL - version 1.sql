-- SQL - Version 1

CREATE SCHEMA `crud` DEFAULT CHARACTER SET utf8 ;

CREATE TABLE `crud`.`user` (
  `id_user` INT NOT NULL,
  `name_user` VARCHAR(100) NOT NULL,
  `fone_user` INT NOT NULL,
  PRIMARY KEY (`id_user`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;
