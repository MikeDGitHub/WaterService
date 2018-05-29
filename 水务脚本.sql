CREATE SCHEMA oauth;

CREATE TABLE oauth.applicationinfo
(
  ApplicationId INT AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  DisplayName   VARCHAR(50)                    COMMENT '应用名称'  NOT  NULL,
  `Create`      VARCHAR(50)                    COMMENT '创建人'    NOT NULL,
  CreateDate    DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间'NOT NULL,
  Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT applicationinfo_ApplicationId_uindex
  UNIQUE (ApplicationId)
)
  COMMENT '应用信息'
  ENGINE = InnoDB; 

CREATE TABLE oauth.departmentinfo
(
  DepId      INT AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  DepName    VARCHAR(50)     COMMENT '部门名称' not NULL,
  ParentId   INT DEFAULT '0' COMMENT '父级ID' not NULL,
  status     INT DEFAULT '1' COMMENT '0禁用1,启用' not NULL,
  `Create`      VARCHAR(50)                    COMMENT '创建人'    NOT NULL,
  CreateDate    DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间'NOT NULL,
  Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT departmentinfo_DepId_uindex
  UNIQUE (DepId)
)
  COMMENT '部门信息'
  ENGINE = InnoDB; 
alter table oauth.departmentinfo AUTO_INCREMENT=1000;
CREATE TABLE oauth.userinfo
(
  UserID       INT AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  UserName     VARCHAR(50)  COMMENT '用户名' NULL,
  LoginName    VARCHAR(50)  COMMENT '登录名' NULL,
  PhoneNumber  CHAR(20)     COMMENT '手机号' NULL,
  LogoImageUrl VARCHAR(200) COMMENT '头像' NULL,
  UserEmail    VARCHAR(100) COMMENT '邮箱' NULL,
  Status     INT DEFAULT '1' COMMENT '0禁用1,启用' not NULL,
  DepId      INT DEFAULT '0' COMMENT '部门' not NULL,
  CONSTRAINT userinfo_UserID_uindex
  UNIQUE (UserID)
)
  COMMENT '用户表'
  ENGINE = InnoDB; 


CREATE TABLE oauth.userpassword
(
  UserID        INT          COMMENT 'userinfo表主键'not NULL,
  PasswordType  VARCHAR(50)  NULL,
  LoginName     VARCHAR(50)  COMMENT '登录名'not NULL,
  AlgorithmType CHAR(20)     NULL,
  PassWord      VARCHAR(200) COMMENT '密码'not NULL
)
  COMMENT '用户密码表'
  ENGINE = InnoDB; 



CREATE SCHEMA acl;

CREATE TABLE acl.applicationanduser
(
  ApplicationId INT COMMENT 'applicationinfo表主键'not NULL ,
  UserID        INT COMMENT 'userinfo表主键'NOT NULL
)
  ENGINE = InnoDB; 


 CREATE SCHEMA waterservice;


 CREATE TABLE waterservice.attachmentinfo
(
  AttachmentId INT AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  MeterId      INT                            COMMENT '' not  NULL,
  ImgUrl       VARCHAR(200)                       NULL,
  `Create`     VARCHAR(50)                        COMMENT '创建人' not null,
  CreateDate   DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间' not null,
  GenreId      INT                                COMMENT '类型表主键' not null,
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT attachmentinfo_AttachmentId_uindex
  UNIQUE (AttachmentId)
)
  COMMENT '附件信息'
  ENGINE = InnoDB; 

-- auto-generated definition
CREATE TABLE waterservice.genreinfo
(
  GenreId    INT AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  GenreName  VARCHAR(50)                   COMMENT '类型名称' not  NULL,
  status     INT DEFAULT '1' COMMENT '0禁用1,启用' not NULL,
  `Create`      VARCHAR(50)                    COMMENT '创建人'    NOT NULL,
  CreateDate    DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间'NOT NULL,
  Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT GenreInfo_GenreId_uindex
  UNIQUE (GenreId)
)
  COMMENT '类型表'
  ENGINE = InnoDB; 
alter table waterservice.genreinfo AUTO_INCREMENT=1000;


CREATE TABLE waterservice.typeinfo
(
  TypeId     INT AUTO_INCREMENT          PRIMARY KEY COMMENT '主键(自增长)',
  TypeName   VARCHAR(50)                        COMMENT '类型名称' not  NULL,
   status     INT DEFAULT '1' COMMENT '0禁用1,启用' not NULL,
  `Create`      VARCHAR(50)                    COMMENT '创建人'    NOT NULL,
  CreateDate    DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间'NOT NULL,
  Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT TypeInfo_TypeId_uindex
  UNIQUE (TypeId)
)
  COMMENT '类型表'
  ENGINE = InnoDB; 
alter table waterservice.typeinfo AUTO_INCREMENT=2000;


CREATE TABLE waterservice.maintenanceinfo
(
  MaintenanceId INT AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  MeterId       INT                              COMMENT '' not  NULL,
  GenreId       INT                              COMMENT '' not  NULL,
  TypeId        INT                              COMMENT '' not  NULL,
  InstallTime   DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '安装时间' not  NULL,
  `Create`      VARCHAR(50)                        COMMENT '创建人'    NOT NULL,
  CreateDate    DATETIME DEFAULT CURRENT_TIMESTAMP  COMMENT '创建时间'NOT NULL,
  ReplaceTime   DATETIME                           NULL,
  CONSTRAINT maintenanceinfo_MaintenanceId_uindex
  UNIQUE (MaintenanceId)
)
  COMMENT '维保信息'
  ENGINE = InnoDB; 

CREATE TABLE waterservice.trackinfo
(
  TrackId    INT AUTO_INCREMENT  PRIMARY KEY  COMMENT '主键(自增长)',
  Coordinate LONGTEXT                          COMMENT '轨迹信息' not  NULL,
  StartLat   DOUBLE  DEFAULT '0'                COMMENT '起始经度' not  NULL,
  StartLon   DOUBLE  DEFAULT '0'                 COMMENT '起始纬度' not  NULL,
  EndLat     DOUBLE  DEFAULT '0'                  COMMENT '结束经度' not  NULL,
  EndLon     DOUBLE  DEFAULT '0'                 COMMENT '结束纬度' not  NULL,
  `Create`   VARCHAR(50)                        COMMENT '创建人'    NOT NULL,
  CreateDate DATETIME DEFAULT CURRENT_TIMESTAMP   COMMENT '创建时间'NOT NULL,
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT TrackInfo_TrackId_uindex
  UNIQUE (TrackId)
)
  COMMENT '轨迹信息'
  ENGINE = InnoDB; 


CREATE TABLE waterservice.userinfo
(
  UserId      INT AUTO_INCREMENT          PRIMARY KEY COMMENT '主键(自增长)',
  UserName    VARCHAR(200)                COMMENT '用户名' not  NULL,
  UserAddress VARCHAR(200)                COMMENT '用户地址' not  NULL,
  UserPhone   CHAR(20)                    COMMENT '手机号' not  NULL,
  MeterId     INT                          COMMENT '' not  NULL,
  Remark      VARCHAR(200)                 COMMENT '备注'      NULL,
   `Create`   VARCHAR(50)                        COMMENT '创建人'    NOT NULL,
  CreateDate DATETIME DEFAULT CURRENT_TIMESTAMP   COMMENT '创建时间'NOT NULL,
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT userinfo_UserId_uindex
  UNIQUE (UserId)
)
  COMMENT '用户信息'
  ENGINE = InnoDB; 



  CREATE TABLE waterservice.drainageinfo
(
  DrainageId   INT AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  DrainageCode VARCHAR(50)                     COMMENT 'code'    NOT NULL,
  DrainageName VARCHAR(50)                     COMMENT 'name'    NOT NULL,
  TypeId       INT                               COMMENT '类型'    NOT NULL,
  GenreId      INT                                 COMMENT '类型' NOT NULL,
  Caliber      DOUBLE  DEFAULT '0'               COMMENT '口径' NOT  NULL,
  Lat          DOUBLE  DEFAULT '0'                COMMENT '经度' NOT  NULL,
  Lon          DOUBLE  DEFAULT '0'                COMMENT '纬度' NOT  NULL,
  Remark       VARCHAR(200)                        COMMENT '备注'NULL,
  `Create`   VARCHAR(50)                        COMMENT '创建人'    NOT NULL,
  CreateDate DATETIME DEFAULT CURRENT_TIMESTAMP   COMMENT '创建时间'NOT NULL,
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT drainageinfo_DrainageId_uindex
  UNIQUE (DrainageId)
)
  COMMENT '泄水信息'
  ENGINE = InnoDB; 
alter table waterservice.drainageinfo AUTO_INCREMENT=1000000;


CREATE TABLE waterservice.exhaustinfo
(
  ExhaustId   INT          AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  ExhaustCode VARCHAR(50)                         COMMENT 'code'    NOT NULL,
  ExhaustName VARCHAR(50)                         COMMENT 'name'    NOT NULL,
  TypeId       INT                               COMMENT '类型'    NOT NULL,
  GenreId      INT                                 COMMENT '类型' NOT NULL,
  Caliber      DOUBLE  DEFAULT '0'               COMMENT '口径' NOT  NULL,
  Lat          DOUBLE  DEFAULT '0'                COMMENT '经度' NOT  NULL,
  Lon          DOUBLE  DEFAULT '0'                COMMENT '纬度' NOT  NULL,
  Remark       VARCHAR(200)                        COMMENT '备注'NULL,
  `Create`   VARCHAR(50)                        COMMENT '创建人'    NOT NULL,
  CreateDate DATETIME DEFAULT CURRENT_TIMESTAMP   COMMENT '创建时间'NOT NULL,
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT exhaustinfo_ExhaustId_uindex
  UNIQUE (ExhaustId)
)
  COMMENT '排气信息'
  ENGINE = InnoDB; 

alter table waterservice.exhaustinfo AUTO_INCREMENT=2000000;


CREATE TABLE waterservice.pipelineinfo
(
  PipeLineId   INT          AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  PipeLineCode VARCHAR(50)                       COMMENT 'code'    NOT NULL,
  PipeLineName VARCHAR(50)                       COMMENT 'name'    NOT NULL,
  TrackId      INT                                COMMENT '轨迹主键'    NOT NULL,
  TypeId       INT                               COMMENT '类型'    NOT NULL,
  GenreId      INT                                 COMMENT '类型' NOT NULL,
  Caliber      DOUBLE  DEFAULT '0'               COMMENT '口径' NOT  NULL,
  Lat          DOUBLE  DEFAULT '0'                COMMENT '经度' NOT  NULL,
  Lon          DOUBLE  DEFAULT '0'                COMMENT '纬度' NOT  NULL,
  Remark       VARCHAR(200)                        COMMENT '备注'NULL,
  `Create`   VARCHAR(50)                        COMMENT '创建人'    NOT NULL,
  CreateDate DATETIME DEFAULT CURRENT_TIMESTAMP   COMMENT '创建时间'NOT NULL,
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT pipelineinfo_PipeLineId_uindex
  UNIQUE (PipeLineId)
)
  COMMENT '管线信息'
  ENGINE = InnoDB; 
alter table waterservice.pipelineinfo AUTO_INCREMENT=3000000;

CREATE TABLE waterservice.sludgeinfo
(
  SludgeId   INT          AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  SludgeCode VARCHAR(50)                        COMMENT 'code'    NOT NULL,
  SludgeName VARCHAR(50)                         COMMENT 'name'    NOT NULL,
   TypeId       INT                               COMMENT '类型'    NOT NULL,
  GenreId      INT                                 COMMENT '类型' NOT NULL,
  Caliber      DOUBLE  DEFAULT '0'               COMMENT '口径' NOT  NULL,
  Lat          DOUBLE  DEFAULT '0'                COMMENT '经度' NOT  NULL,
  Lon          DOUBLE  DEFAULT '0'                COMMENT '纬度' NOT  NULL,
  Remark       VARCHAR(200)                        COMMENT '备注'NULL,
  `Create`   VARCHAR(50)                        COMMENT '创建人'    NOT NULL,
  CreateDate DATETIME DEFAULT CURRENT_TIMESTAMP   COMMENT '创建时间'NOT NULL,
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT sludgeinfo_SludgeId_uindex
  UNIQUE (SludgeId)
)
  COMMENT '排泥信息'
  ENGINE = InnoDB; 
  alter table waterservice.sludgeinfo AUTO_INCREMENT=4000000;


CREATE TABLE waterservice.valveinfo
(
  ValveId    INT          AUTO_INCREMENT PRIMARY KEY  COMMENT '主键(自增长)',
  ValveCode  VARCHAR(50)                         COMMENT 'code'    NOT NULL,
  ValveName  VARCHAR(50)                     COMMENT 'name'    NOT NULL,
 TypeId       INT                               COMMENT '类型'    NOT NULL,
  GenreId      INT                                 COMMENT '类型' NOT NULL,
  Caliber      DOUBLE  DEFAULT '0'               COMMENT '口径' NOT  NULL,
  Lat          DOUBLE  DEFAULT '0'                COMMENT '经度' NOT  NULL,
  Lon          DOUBLE  DEFAULT '0'                COMMENT '纬度' NOT  NULL,
  Remark       VARCHAR(200)                        COMMENT '备注'NULL,
  `Create`   VARCHAR(50)                        COMMENT '创建人'    NOT NULL,
  CreateDate DATETIME DEFAULT CURRENT_TIMESTAMP   COMMENT '创建时间'NOT NULL,
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT valveinfo_ValveId_uindex
  UNIQUE (ValveId)
)
  COMMENT '阀门信息'
  ENGINE = InnoDB; 
  alter table waterservice.valveinfo AUTO_INCREMENT=5000000;

CREATE TABLE waterservice.watermeterinfo
(
  WaterId    INT         AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  WaterCode  VARCHAR(50)                        COMMENT 'code'    NOT NULL,
  WaterName  VARCHAR(50)                        COMMENT 'name'    NOT NULL,
  TypeId     INT                                   COMMENT '类型'    NOT NULL,
  GenreId    INT                               COMMENT '类型' NOT NULL,
  Acreage    DOUBLE DEFAULT '0'                COMMENT '面积' NOT NULL,
   Caliber      DOUBLE  DEFAULT '0'               COMMENT '口径' NOT  NULL,
  Lat          DOUBLE  DEFAULT '0'                COMMENT '经度' NOT  NULL,
  Lon          DOUBLE  DEFAULT '0'                COMMENT '纬度' NOT  NULL,
  Remark       VARCHAR(200)                        COMMENT '备注'NULL,
  `Create`   VARCHAR(50)                        COMMENT '创建人'    NOT NULL,
  CreateDate DATETIME DEFAULT CURRENT_TIMESTAMP   COMMENT '创建时间'NOT NULL,
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT watermeterinfo_WaterId_uindex
  UNIQUE (WaterId)
)
  COMMENT '水表信息'
  ENGINE = InnoDB; 
  alter table waterservice.watermeterinfo AUTO_INCREMENT=6000000;




insert into oauth.applicationinfo (DisplayName, `Create`, CreateDate) VALUES ('app','admin',now());
insert into oauth.applicationinfo (DisplayName, `Create`, CreateDate) VALUES ('web','admin',now());


INSERT  into waterservice.typeinfo (TypeName, `Create`,CreateDate) VALUES ('主管道','admin',now());


insert into waterservice.genreinfo (GenreName, `Create`, CreateDate) VALUES ('排水','admin',now());
insert into waterservice.genreinfo (GenreName, `Create`, CreateDate) VALUES ('排气','admin',now());
insert into waterservice.genreinfo (GenreName, `Create`, CreateDate) VALUES ('阀门','admin',now());
insert into waterservice.genreinfo (GenreName, `Create`, CreateDate) VALUES ('排泥','admin',now());
insert into waterservice.genreinfo (GenreName, `Create`, CreateDate) VALUES ('水表','admin',now());
insert into waterservice.genreinfo (GenreName, `Create`, CreateDate) VALUES ('管线','admin',now());



insert into oauth.userinfo (UserName, LoginName, PhoneNumber, LogoImageUrl, UserEmail)
VALUES ('admin','admin','15001130082','','admin@qq.com')
insert INTO acl.applicationanduser VALUES (2,1)
insert INTO oauth.userpassword (UserID, PasswordType, LoginName, AlgorithmType, PassWord) 
VALUES (1,'MD5','admin','','C3-1A-C6-05-79-3F-58-0B-38-6C-0F-B5-3F-1B-97-75') 