CREATE SCHEMA oauth;

CREATE TABLE oauth.applicationinfo
(
  ApplicationId INT AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  DisplayName   VARCHAR(50)                    COMMENT '应用名称'    NULL,
  `Create`      VARCHAR(50)                    COMMENT '创建人'     NULL,
  CreateDate    timestamp  NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT applicationinfo_ApplicationId_uindex
  UNIQUE (ApplicationId)
)
  COMMENT '应用信息'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 

CREATE TABLE oauth.departmentinfo
(
  DepId      INT AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  DepName    VARCHAR(50)     COMMENT '部门名称'  NULL,
  ParentId   INT DEFAULT '0' COMMENT '父级ID'  NULL,
  status     INT DEFAULT '1' COMMENT '0禁用1,启用'  NULL,
  `Create`      VARCHAR(50)                    COMMENT '创建人'     NULL,
  CreateDate    timestamp  NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT departmentinfo_DepId_uindex
  UNIQUE (DepId)
)
  COMMENT '部门信息'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 
alter table oauth.departmentinfo AUTO_INCREMENT=1000;
CREATE TABLE oauth.userinfo
(
  UserID       INT AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  UserName     VARCHAR(50)  COMMENT '用户名' NULL,
  LoginName    VARCHAR(50)  COMMENT '登录名' NULL,
  PhoneNumber  CHAR(20)     COMMENT '手机号' NULL,
  LogoImageUrl VARCHAR(200) COMMENT '头像' NULL,
  UserEmail    VARCHAR(100) COMMENT '邮箱' NULL,
  Status     INT DEFAULT '1' COMMENT '0禁用1,启用'  NULL,
  DepId      INT DEFAULT '0' COMMENT '部门'  NULL,
  CONSTRAINT userinfo_UserID_uindex
  UNIQUE (UserID)
)
  COMMENT '用户表'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 


CREATE TABLE oauth.userpassword
(
  UserID        INT          COMMENT 'userinfo表主键' NULL,
  PasswordType  VARCHAR(50)  NULL,
  LoginName     VARCHAR(50)  COMMENT '登录名' NULL,
  AlgorithmType CHAR(20)     NULL,
  PassWord      VARCHAR(200) COMMENT '密码' NULL
)
  COMMENT '用户密码表'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 



CREATE SCHEMA acl;

CREATE TABLE acl.applicationanduser
(
  ApplicationId INT COMMENT 'applicationinfo表主键' NULL ,
  UserID        INT COMMENT 'userinfo表主键' NULL
)
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 


 CREATE SCHEMA waterservice;


 CREATE TABLE waterservice.attachmentinfo
(
  AttachmentId INT AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  MeterId      INT                            COMMENT ''   NULL,
  ImgUrl       VARCHAR(200)                       NULL,
  `Create`         VARCHAR(50)                        COMMENT '创建人'  null,
  CreateDate   timestamp  null DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间' ,
  GenreId      INT                                COMMENT '类型表主键'  null,
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  Resourceid    INT                           COMMENT 'Resourceid'    NULL,
  CONSTRAINT attachmentinfo_AttachmentId_uindex
  UNIQUE (AttachmentId)
)
  COMMENT '附件信息'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 

-- auto-generated definition
CREATE TABLE waterservice.genreinfo
(
  GenreId    INT AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  GenreName  VARCHAR(50)                   COMMENT '类型名称'   NULL,
  status     INT DEFAULT '1' COMMENT '0禁用1,启用'  NULL,
  `Create`      VARCHAR(50)                    COMMENT '创建人'     NULL,
  CreateDate    timestamp  null DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT GenreInfo_GenreId_uindex
  UNIQUE (GenreId)
)
  COMMENT '类型表'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 
alter table waterservice.genreinfo AUTO_INCREMENT=1000;


CREATE TABLE waterservice.typeinfo
(
  TypeId     INT AUTO_INCREMENT          PRIMARY KEY COMMENT '主键(自增长)',
  TypeName   VARCHAR(50)                        COMMENT '类型名称'   NULL,
   status     INT DEFAULT '1' COMMENT '0禁用1,启用'  NULL,
  `Create`      VARCHAR(50)                    COMMENT '创建人'     NULL,
  CreateDate    timestamp  null DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT TypeInfo_TypeId_uindex
  UNIQUE (TypeId)
)
  COMMENT '类型表'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 
alter table waterservice.typeinfo AUTO_INCREMENT=2000;

CREATE TABLE waterservice.modelinfo
(
  ModelId    INT AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  ModelName  VARCHAR(50)                   COMMENT '类型名称'   NULL,
  status     INT DEFAULT '1' COMMENT '0禁用1,启用'  NULL,
  `Create`       VARCHAR(50)                    COMMENT '创建人'     NULL,
  CreateDate    timestamp  null DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT Modelinfo_ModelId_uindex
  UNIQUE (ModelId)
)
  COMMENT '类型表'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 
alter table waterservice.modelinfo AUTO_INCREMENT=3000;


CREATE TABLE waterservice.maintenanceinfo
(
  MaintenanceId INT AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  MeterId       INT                              COMMENT ''   NULL,
  GenreId       INT                              COMMENT ''   NULL,
  TypeId        INT                              COMMENT ''   NULL,
  InstallTime   DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '安装时间'   NULL,
  `Create`      VARCHAR(50)                        COMMENT '创建人'     NULL,
  CreateDate    timestamp  NULL DEFAULT CURRENT_TIMESTAMP  COMMENT '创建时间',
  ReplaceTime   DATETIME                           NULL,
  CONSTRAINT maintenanceinfo_MaintenanceId_uindex
  UNIQUE (MaintenanceId)
)
  COMMENT '维保信息'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 

CREATE TABLE waterservice.trackinfo
(
  TrackId    INT AUTO_INCREMENT  PRIMARY KEY  COMMENT '主键(自增长)',
  Coordinate LONGTEXT                          COMMENT '轨迹信息'   NULL,
  StartLat   DOUBLE  DEFAULT '0'                COMMENT '起始经度'   NULL,
  StartLon   DOUBLE  DEFAULT '0'                 COMMENT '起始纬度'   NULL,
  EndLat     DOUBLE  DEFAULT '0'                  COMMENT '结束经度'   NULL,
  EndLon     DOUBLE  DEFAULT '0'                 COMMENT '结束纬度'   NULL,
  `Create`   VARCHAR(50)                        COMMENT '创建人'     NULL,
  CreateDate timestamp  NULL DEFAULT CURRENT_TIMESTAMP   COMMENT '创建时间',
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT TrackInfo_TrackId_uindex
  UNIQUE (TrackId)
)
  COMMENT '轨迹信息'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 


CREATE TABLE waterservice.userinfo
(
  UserId      INT AUTO_INCREMENT          PRIMARY KEY COMMENT '主键(自增长)',
  UserName    VARCHAR(200)                COMMENT '用户名'   NULL,
  UserAddress VARCHAR(200)                COMMENT '用户地址'   NULL,
  UserPhone   CHAR(20)                    COMMENT '手机号'   NULL,
  MeterId     INT                          COMMENT ''   NULL,
  Remark      VARCHAR(200)                 COMMENT '备注'      NULL,
   `Create`   VARCHAR(50)                        COMMENT '创建人'     NULL,
  CreateDate timestamp  NULL DEFAULT CURRENT_TIMESTAMP   COMMENT '创建时间',
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT userinfo_UserId_uindex
  UNIQUE (UserId)
)
  COMMENT '用户信息'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 



  CREATE TABLE waterservice.drainageinfo
(
  DrainageId   INT AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  DrainageCode VARCHAR(50)                     COMMENT 'code'     NULL,
  DrainageName VARCHAR(50)                     COMMENT 'name'     NULL,
  TypeId       INT                               COMMENT '类型'     NULL,
  GenreId      INT                                 COMMENT '类型'  NULL,
  Caliber      DOUBLE  DEFAULT '0'               COMMENT '口径'   NULL,
  Lat          DOUBLE  DEFAULT '0'                COMMENT '经度'   NULL,
  Lon          DOUBLE  DEFAULT '0'                COMMENT '纬度'   NULL,
  Remark       VARCHAR(200)                        COMMENT '备注'NULL,
  `Create`   VARCHAR(50)                        COMMENT '创建人'     NULL,
  CreateDate timestamp  NULL DEFAULT CURRENT_TIMESTAMP   COMMENT '创建时间',
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT drainageinfo_DrainageId_uindex
  UNIQUE (DrainageId)
)
  COMMENT '泄水信息'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 
alter table waterservice.drainageinfo AUTO_INCREMENT=1000000;


CREATE TABLE waterservice.exhaustinfo
(
  ExhaustId   INT          AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  ExhaustCode VARCHAR(50)                         COMMENT 'code'     NULL,
  ExhaustName VARCHAR(50)                         COMMENT 'name'     NULL,
  TypeId       INT                               COMMENT '类型'     NULL,
  GenreId      INT                                 COMMENT '类型'  NULL,
  Caliber      DOUBLE  DEFAULT '0'               COMMENT '口径'   NULL,
  Lat          DOUBLE  DEFAULT '0'                COMMENT '经度'   NULL,
  Lon          DOUBLE  DEFAULT '0'                COMMENT '纬度'   NULL,
  Remark       VARCHAR(200)                        COMMENT '备注'NULL,
  `Create`   VARCHAR(50)                        COMMENT '创建人'     NULL,
  CreateDate timestamp  NULL DEFAULT CURRENT_TIMESTAMP   COMMENT '创建时间',
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT exhaustinfo_ExhaustId_uindex
  UNIQUE (ExhaustId)
)
  COMMENT '排气信息'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 

alter table waterservice.exhaustinfo AUTO_INCREMENT=2000000;


CREATE TABLE waterservice.pipelineinfo
(
  PipeLineId   INT          AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  PipeLineCode VARCHAR(50)                       COMMENT 'code'     NULL,
  PipeLineName VARCHAR(50)                       COMMENT 'name'     NULL,
  TrackId      INT                                COMMENT '轨迹主键'     NULL,
  TypeId       INT                               COMMENT '类型'     NULL,
  GenreId      INT                                 COMMENT '类型'  NULL,
  Acreage    DOUBLE DEFAULT '0'                COMMENT '面积'  NULL,
  Caliber      DOUBLE  DEFAULT '0'               COMMENT '口径'   NULL,
  Lat          DOUBLE  DEFAULT '0'                COMMENT '经度'   NULL,
  Lon          DOUBLE  DEFAULT '0'                COMMENT '纬度'   NULL,
  ModelId      INT                                COMMENT ''   NULL,
  ModelName       VARCHAR(200)                        COMMENT ''NULL,
  Remark       VARCHAR(200)                        COMMENT '备注'NULL,
  StartAddress VARCHAR(200)                        COMMENT '起始地址'NULL,
  EndAddress VARCHAR(200)                        COMMENT '结束地址'NULL,
  `Create`   VARCHAR(50)                        COMMENT '创建人'     NULL,
  CreateDate timestamp  NULL DEFAULT CURRENT_TIMESTAMP   COMMENT '创建时间',
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT pipelineinfo_PipeLineId_uindex
  UNIQUE (PipeLineId)
)
  COMMENT '管线信息'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 
alter table waterservice.pipelineinfo AUTO_INCREMENT=3000000;

CREATE TABLE waterservice.sludgeinfo
(
  SludgeId   INT          AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  SludgeCode VARCHAR(50)                        COMMENT 'code'     NULL,
  SludgeName VARCHAR(50)                         COMMENT 'name'     NULL,
   TypeId       INT                               COMMENT '类型'     NULL,
  GenreId      INT                                 COMMENT '类型'  NULL,
  Caliber      DOUBLE  DEFAULT '0'               COMMENT '口径'   NULL,
  Lat          DOUBLE  DEFAULT '0'                COMMENT '经度'   NULL,
  Lon          DOUBLE  DEFAULT '0'                COMMENT '纬度'   NULL,
  Remark       VARCHAR(200)                        COMMENT '备注'NULL,
  `Create`   VARCHAR(50)                        COMMENT '创建人'     NULL,
  CreateDate timestamp  NULL DEFAULT CURRENT_TIMESTAMP   COMMENT '创建时间',
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT sludgeinfo_SludgeId_uindex
  UNIQUE (SludgeId)
)
  COMMENT '排泥信息'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 
  alter table waterservice.sludgeinfo AUTO_INCREMENT=4000000;


CREATE TABLE waterservice.valveinfo
(
  ValveId    INT          AUTO_INCREMENT PRIMARY KEY  COMMENT '主键(自增长)',
  ValveCode  VARCHAR(50)                         COMMENT 'code'     NULL,
  ValveName  VARCHAR(50)                     COMMENT 'name'     NULL,
 TypeId       INT                               COMMENT '类型'     NULL,
  GenreId      INT                                 COMMENT '类型'  NULL,
  Caliber      DOUBLE  DEFAULT '0'               COMMENT '口径'   NULL,
  Lat          DOUBLE  DEFAULT '0'                COMMENT '经度'   NULL,
  Lon          DOUBLE  DEFAULT '0'                COMMENT '纬度'   NULL,
  Remark       VARCHAR(200)                        COMMENT '备注'NULL,
  `Create`   VARCHAR(50)                        COMMENT '创建人'     NULL,
  CreateDate timestamp  NULL DEFAULT CURRENT_TIMESTAMP   COMMENT '创建时间',
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT valveinfo_ValveId_uindex
  UNIQUE (ValveId)
)
  COMMENT '阀门信息'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 
  alter table waterservice.valveinfo AUTO_INCREMENT=5000000;

CREATE TABLE waterservice.watermeterinfo
(
  WaterId    INT         AUTO_INCREMENT PRIMARY KEY COMMENT '主键(自增长)',
  WaterCode  VARCHAR(50)                        COMMENT 'code'     NULL,
  WaterName  VARCHAR(50)                        COMMENT 'name'     NULL,
  TypeId     INT                                   COMMENT '类型'     NULL,
  GenreId    INT                               COMMENT '类型'  NULL,
  Acreage    DOUBLE DEFAULT '0'                COMMENT '面积'  NULL,
   Caliber      DOUBLE  DEFAULT '0'               COMMENT '口径'   NULL,
  Lat          DOUBLE  DEFAULT '0'                COMMENT '经度'   NULL,
  Lon          DOUBLE  DEFAULT '0'                COMMENT '纬度'   NULL,
  Remark       VARCHAR(200)                        COMMENT '备注'NULL,
  `Create`   VARCHAR(50)                        COMMENT '创建人'     NULL,
  CreateDate timestamp  NULL DEFAULT CURRENT_TIMESTAMP   COMMENT '创建时间',
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT watermeterinfo_WaterId_uindex
  UNIQUE (WaterId)
)
  COMMENT '水表信息'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 
  alter table waterservice.watermeterinfo AUTO_INCREMENT=6000000;



CREATE TABLE waterservice.firefightinginfo
(
  FireFightingId    INT          AUTO_INCREMENT PRIMARY KEY  COMMENT '主键(自增长)',
  FireFightingCode  VARCHAR(50)                         COMMENT 'code'     NULL,
  FireFightingName  VARCHAR(50)                     COMMENT 'name'     NULL,
 TypeId       INT                               COMMENT '类型'     NULL,
  GenreId      INT                                 COMMENT '类型'  NULL,
  Caliber      DOUBLE  DEFAULT '0'               COMMENT '口径'   NULL,
  Lat          DOUBLE  DEFAULT '0'                COMMENT '经度'   NULL,
  Lon          DOUBLE  DEFAULT '0'                COMMENT '纬度'   NULL,
  Remark       VARCHAR(200)                        COMMENT '备注'NULL,
  `Create`   VARCHAR(50)                        COMMENT '创建人'     NULL,
  CreateDate timestamp  NULL DEFAULT CURRENT_TIMESTAMP   COMMENT '创建时间',
   Modify        VARCHAR(50)                    COMMENT '修改建人'    NULL,
  ModifyDate    DATETIME                       COMMENT '修改时间'    NULL,
  CONSTRAINT firefightinginfo_FireFightingId_uindex
  UNIQUE (FireFightingId)
)
  COMMENT '消防信息'
  ENGINE = InnoDB DEFAULT CHARSET=utf8; 
  alter table waterservice.firefightinginfo AUTO_INCREMENT=7000000;


insert into oauth.applicationinfo (DisplayName, `Create`, CreateDate) VALUES ('app','admin',now());
insert into oauth.applicationinfo (DisplayName, `Create`, CreateDate) VALUES ('web','admin',now());


INSERT  into waterservice.typeinfo (TypeName, `Create`,CreateDate) VALUES ('主管道','admin',now());


insert into waterservice.genreinfo (GenreName, `Create`, CreateDate) VALUES ('排水','admin',now());
insert into waterservice.genreinfo (GenreName, `Create`, CreateDate) VALUES ('排气','admin',now());
insert into waterservice.genreinfo (GenreName, `Create`, CreateDate) VALUES ('阀门','admin',now());
insert into waterservice.genreinfo (GenreName, `Create`, CreateDate) VALUES ('排泥','admin',now());
insert into waterservice.genreinfo (GenreName, `Create`, CreateDate) VALUES ('水表','admin',now());
insert into waterservice.genreinfo (GenreName, `Create`, CreateDate) VALUES ('管线','admin',now());
insert into waterservice.genreinfo (GenreName, `Create`, CreateDate) VALUES ('消防','admin',now());



insert into oauth.userinfo (UserName, LoginName, PhoneNumber, LogoImageUrl, UserEmail)
VALUES ('admin','admin','15001130082','','admin@qq.com');
insert INTO acl.applicationanduser VALUES (2,1);
insert INTO oauth.userpassword (UserID, PasswordType, LoginName, AlgorithmType, PassWord) 
VALUES (1,'MD5','admin','','C3-1A-C6-05-79-3F-58-0B-38-6C-0F-B5-3F-1B-97-75') ;


create view	pipelineview 
as

select pipelineid,pipelinecode ,acreage,pipelinename,trackid,caliber,startaddress,endaddress,ui.userid,ui.username,ui.useraddress,ui.userphone,ui.remark,ui.`create`,ui.createdate,ui.modify,ui.modifydate,gi.genreid,gi.genrename,ui.userCode,ti.typeid,ti.typename,modelid,modelname from  waterservice.pipelineinfo va join waterservice.userinfo ui on ui.meterid = va.pipelineid join waterservice.genreinfo gi on gi.genreid = va.genreid join waterservice.typeinfo ti on ti.typeid = va.typeid ;

create view drainageview
as
select drainageid,drainagecode ,drainagename,caliber,lat,lon,ui.userid,ui.username,ui.useraddress,ui.userphone,ui.remark,ui.`create`,ui.createdate,ui.modify,ui.modifydate,gi.genreid,gi.genrename,ui.userCode,ti.typeid,ti.typename from  waterservice.drainageinfo dr join waterservice.userinfo ui on ui.meterid = dr.drainageid join waterservice.genreinfo gi on gi.genreid = dr.genreid join waterservice.typeinfo ti on ti.typeid = dr.typeid;

create view exhaustview
as
select exhaustid,exhaustcode ,exhaustname,caliber,lat,lon,ui.userid,ui.username,ui.useraddress,ui.userphone,ui.remark,ui.`create`,ui.createdate,ui.modify,ui.modifydate,gi.genreid,gi.genrename,ui.userCode,ti.typeid,ti.typename from  waterservice.exhaustinfo ex join waterservice.userinfo ui on ui.meterid = ex.exhaustid join waterservice.genreinfo gi on gi.genreid = ex.genreid join waterservice.typeinfo ti on ti.typeid = ex.typeid;


create view sludgeview
as
select sludgeid,sludgecode ,sludgename,caliber,lat,lon,ui.userid,ui.username,ui.useraddress,ui.userphone,ui.remark,ui.`create`,ui.createdate,ui.modify,ui.modifydate,gi.genreid,gi.genrename,ui.userCode,ti.typeid,ti.typename from  waterservice.sludgeinfo va join waterservice.userinfo ui on ui.meterid = va.sludgeid join waterservice.genreinfo gi on gi.genreid = va.genreid join waterservice.typeinfo ti on ti.typeid = va.typeid ;

create view valveview
as
select valveid,valvecode  ,valvename,caliber,lat,lon,ui.userid,ui.username,ui.useraddress,ui.userphone,ui.remark,ui.`create`,ui.createdate,ui.modify,ui.modifydate,gi.genreid,gi.genrename,ui.userCode,ti.typeid,ti.typename from  waterservice.valveinfo va join waterservice.userinfo ui on ui.meterid = va.valveid join waterservice.genreinfo gi on gi.genreid = va.genreid join waterservice.typeinfo ti on ti.typeid = va.typeid ;

create view watermeterview

as

select waterid,watercode ,watername,acreage,caliber,lat,lon,ui.userid,ui.username,ui.useraddress,ui.userphone,ui.remark,ui.`create`,ui.createdate,ui.modify,ui.modifydate,gi.genreid,gi.genrename,ui.userCode,ti.typeid,ti.typename from  waterservice.watermeterinfo va join waterservice.userinfo ui on ui.meterid = va.waterid join waterservice.genreinfo gi on gi.genreid = va.genreid join waterservice.typeinfo ti on ti.typeid = va.typeid;

create view firefightingview
as
select firefightingid,firefightingcode  ,firefightingname,caliber,lat,lon,ui.userid,ui.username,ui.useraddress,ui.userphone,ui.remark,ui.`create`,ui.createdate,ui.modify,ui.modifydate,gi.genreid,gi.genrename,ui.userCode,ti.typeid,ti.typename from  waterservice.firefightinginfo va join waterservice.userinfo ui on ui.meterid = va.firefightingid join waterservice.genreinfo gi on gi.genreid = va.genreid join waterservice.typeinfo ti on ti.typeid = va.typeid ;

ALTER TABLE waterservice.userinfo ADD UserCode varchar(50) NULL;