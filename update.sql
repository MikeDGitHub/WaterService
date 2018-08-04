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
  

insert into waterservice.genreinfo (GenreName, `Create`, CreateDate) VALUES ('消防','admin',now());

ALTER TABLE waterservice.userinfo ADD UserCode varchar(50) NULL;


alter view	pipelineview
as

select pipelineid,pipelinecode ,acreage,pipelinename,trackid,caliber,startaddress,endaddress,ui.userid,ui.username,ui.useraddress,ui.userphone,ui.remark,ui.`create`,ui.createdate,ui.modify,ui.modifydate,gi.genreid,gi.genrename,ui.userCode,ti.typeid,ti.typename,modelid,modelname from  waterservice.pipelineinfo va join waterservice.userinfo ui on ui.meterid = va.pipelineid join waterservice.genreinfo gi on gi.genreid = va.genreid join waterservice.typeinfo ti on ti.typeid = va.typeid;

alter view drainageview
as
select drainageid,drainagecode ,drainagename,caliber,lat,lon,ui.userid,ui.username,ui.useraddress,ui.userphone,ui.remark,ui.`create`,ui.createdate,ui.modify,ui.modifydate,gi.genreid,gi.genrename,ui.userCode,ti.typeid,ti.typename from  waterservice.drainageinfo dr join waterservice.userinfo ui on ui.meterid = dr.drainageid join waterservice.genreinfo gi on gi.genreid = dr.genreid join waterservice.typeinfo ti on ti.typeid = dr.typeid;

alter view exhaustview
as
select exhaustid,exhaustcode ,exhaustname,caliber,lat,lon,ui.userid,ui.username,ui.useraddress,ui.userphone,ui.remark,ui.`create`,ui.createdate,ui.modify,ui.modifydate,gi.genreid,gi.genrename,ui.userCode,ti.typeid,ti.typename from  waterservice.exhaustinfo ex join waterservice.userinfo ui on ui.meterid = ex.exhaustid join waterservice.genreinfo gi on gi.genreid = ex.genreid join waterservice.typeinfo ti on ti.typeid = ex.typeid;


alter view sludgeview
as
select sludgeid,sludgecode ,sludgename,caliber,lat,lon,ui.userid,ui.username,ui.useraddress,ui.userphone,ui.remark,ui.`create`,ui.createdate,ui.modify,ui.modifydate,gi.genreid,gi.genrename,ui.userCode,ti.typeid,ti.typename from  waterservice.sludgeinfo va join waterservice.userinfo ui on ui.meterid = va.sludgeid join waterservice.genreinfo gi on gi.genreid = va.genreid join waterservice.typeinfo ti on ti.typeid = va.typeid;

alter view valveview
as
select valveid,valvecode  ,valvename,caliber,lat,lon,ui.userid,ui.username,ui.useraddress,ui.userphone,ui.remark,ui.`create`,ui.createdate,ui.modify,ui.modifydate,gi.genreid,gi.genrename,ui.userCode,ti.typeid,ti.typename from  waterservice.valveinfo va join waterservice.userinfo ui on ui.meterid = va.valveid join waterservice.genreinfo gi on gi.genreid = va.genreid join waterservice.typeinfo ti on ti.typeid = va.typeid;

alter view watermeterview

as

select waterid,watercode ,watername,acreage,caliber,lat,lon,ui.userid,ui.username,ui.useraddress,ui.userphone,ui.remark,ui.`create`,ui.createdate,ui.modify,ui.modifydate,gi.genreid,gi.genrename,ui.userCode,ti.typeid,ti.typename from  waterservice.watermeterinfo va join waterservice.userinfo ui on ui.meterid = va.waterid join waterservice.genreinfo gi on gi.genreid = va.genreid join waterservice.typeinfo ti on ti.typeid = va.typeid;

alter view firefightingview
as
select firefightingid,firefightingcode  ,firefightingname,caliber,lat,lon,ui.userid,ui.username,ui.useraddress,ui.userphone,ui.remark,ui.`create`,ui.createdate,ui.modify,ui.modifydate,gi.genreid,gi.genrename,ui.userCode,ti.typeid,ti.typename from  waterservice.firefightinginfo va join waterservice.userinfo ui on ui.meterid = va.firefightingid join waterservice.genreinfo gi on gi.genreid = va.genreid join waterservice.typeinfo ti on ti.typeid = va.typeid;

