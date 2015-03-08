/* CLEAR CACHE */
alter system flush shared_pool;

/* VIEW SERVER HOST NAME */
select host_name from v$instance;

/* CHECK CURREN SID (session ID) */
select sys_context('userenv','sessionid') Session_ID from dual;

/* VENDORS TABLE CREATION */ ------------------------------------------------------------------------------
CREATE TABLE VENDORS 
(
  ID NUMBER(38,0) NOT NULL 
, VENDORNAME NVARCHAR2(200) NOT NULL 
, CONSTRAINT VENDORS_PK PRIMARY KEY 
  (
    ID 
  )
  ENABLE 
);

CREATE SEQUENCE VENDORS_SEQ2;

CREATE TRIGGER VENDORS_TRG 
BEFORE INSERT ON VENDORS 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    IF INSERTING AND :NEW.ID IS NULL THEN
      SELECT VENDORS_SEQ3.NEXTVAL INTO :NEW.ID FROM SYS.DUAL;
    END IF;
  END COLUMN_SEQUENCES;
END;
/

-----------------------------------------------------------------------------------------------
 
/* VENDORS TABLE INSERT */---------------------------------------------------------------------
INSERT INTO VENDORS (VENDORNAME) 
VALUES('Iablanska Halva corp.');
INSERT INTO VENDORS (VENDORNAME) 
VALUES('Kamenitza corp.');
INSERT INTO VENDORS (VENDORNAME) 
VALUES('Zagorka corp.');
INSERT INTO VENDORS (VENDORNAME) 
VALUES('Carlsberg Bulgaria corp.');
INSERT INTO VENDORS (VENDORNAME) 
VALUES('Boliarka BT corp.');
INSERT INTO VENDORS (VENDORNAME) 
VALUES('Burgaska Konserva corp.');
INSERT INTO VENDORS (VENDORNAME) 
VALUES('Dedo Stafid ET.');

/* MEASURES TABLE CREATION */-----------------------------------------------------------
CREATE TABLE MEASURES 
(
  ID NUMBER(38,0) NOT NULL 
, MEASURENAME NVARCHAR2(200) NOT NULL 
, CONSTRAINT MEASURES_PK PRIMARY KEY 
  (
    ID 
  )
  ENABLE 
);

CREATE SEQUENCE MEASURES_SEQ3;

CREATE TRIGGER MEASURES_TRG 
BEFORE INSERT ON MEASURES 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    IF INSERTING AND :NEW.ID IS NULL THEN
      SELECT MEASURES_SEQ3.NEXTVAL INTO :NEW.ID FROM SYS.DUAL;
    END IF;
  END COLUMN_SEQUENCES;
END;
/

/* MEASURES TABLE INSERT */------------------------------------------------------------------
INSERT INTO MEASURES (MEASURENAME)
VALUES ('liters');
INSERT INTO MEASURES (MEASURENAME)
VALUES ('pieces');
INSERT INTO MEASURES (MEASURENAME)
VALUES ('grams');
INSERT INTO MEASURES (MEASURENAME)
VALUES ('kilograms');
INSERT INTO MEASURES (MEASURENAME)
VALUES ('meters');
INSERT INTO MEASURES (MEASURENAME)
VALUES ('centimeters');
INSERT INTO MEASURES (MEASURENAME)
VALUES ('milimeters');
INSERT INTO MEASURES (MEASURENAME)
VALUES ('packages');
INSERT INTO MEASURES (MEASURENAME)
VALUES ('boxes');
INSERT INTO MEASURES (MEASURENAME)
VALUES ('trucks');
--------------------------------------------------------------------------------------

/* PRODUCTS TABLE CREATION */ -------------------------------------------------------------------
CREATE TABLE PRODUCTS 
(
  ID NUMBER(38, 0) NOT NULL 
, VENDORID NUMBER(38, 0) NOT NULL 
, PRODUCTNAME NVARCHAR2(200) NOT NULL 
, MEASUREID NUMBER(38, 0) NOT NULL 
, PRICE NUMBER(19, 4) 
,CONSTRAINT FK_PRODUCTS_MEASURES FOREIGN KEY (MEASUREID)
REFERENCES MEASURES(ID)
,CONSTRAINT FK_PRODUCTS_VENDORS FOREIGN KEY (VENDORID)
REFERENCES VENDORS(ID)
, CONSTRAINT PRODUCTS_PK PRIMARY KEY 
  (
    ID 
  )
  ENABLE 
);

ALTER TABLE PRODUCTS
ADD CONSTRAINT PRODUCTS_MEASURES_FK FOREIGN KEY
(
  MEASUREID 
)
REFERENCES MEASURES
(
  ID 
)
ENABLE;

ALTER TABLE PRODUCTS
ADD CONSTRAINT PRODUCTS_VENDORS_FK FOREIGN KEY
(
  VENDORID 
)
REFERENCES VENDORS
(
  ID 
)
ENABLE;


/* PRODUCTS INSERTS */----------------------------------------------------------------------

INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE)
VALUES(1,'Halva',3,2.55);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE)
VALUES(6,'Konserva "Skumria v Sobstven Sos"',3,1.80);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE)
VALUES(6,'Konserva "Giuvech"',3,3.33);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE)
VALUES(7,'Fastuci "Pechena Semka"',3,1.70);

INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(2,'Beer "Astika"',1,1.80);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(2,'Beer "Becks"',1,1.55);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(2,'Beer "Staropramen"',1,1.66);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(2,'Beer "Slavena"',1,1.10);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(2,'Beer "Burgasko"',1,1.20);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(2,'Beer "Stella Artois"',1,1.70);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(2,'Beer "Kamenitza"',1,1.40);

INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(3,'Beer "Ariana"',1,1.20);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(3,'Beer "Zagorka"',1,1.50);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(3,'Beer "Stolichno"',1,2.00);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(3,'Beer "Amstel"',1,2.20);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(3,'Beer "Heineken"',1,2.50);

INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(4,'Beer "Shumensko"',1,1.20);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(4,'Beer "Pirinsko"',1,1.20);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(4,'Beer "Carlsberg"',1,1.80);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(4,'Beer "Tuborg"',1,1.70);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(4,'Beer "Budvaiser"',1,2.10);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(4,'Beer "Holsten"',1,1.50);

INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(5,'Beer "Boliarka"',1,1.30);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(5,'Beer "Balkansko"',1,1.20);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(5,'Beer "Diana"',1,1.40);
INSERT INTO PRODUCTS (VENDORID,PRODUCTNAME,MEASUREID,PRICE) 
VALUES(5,'Beer "Caltenberg"',1,1.80);


