﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Common;
using System.Data.SQLite;
using System.Data;

namespace Dal
{
    public class TeacherDal
    {
        public Teacher SelectById(Teacher model)
        {
            string sql = "select * from teacher where id=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("id",model.id)
            };
            //执行查询，获取数据
            DataTable table = SqliteHelper.Select(sql, ps);
            //构造数据集合
            List<Teacher> list = new List<Teacher>();
            //遍历数据表，将数据转存到集合中
            foreach (DataRow row in table.Rows)
            {
                list.Add(new Teacher()
                {
                    id = Convert.ToInt32(row["id"]),
                    teacher_id = Convert.ToInt32(row["teacher_id"]),
                    password = row["password"].ToString(),
                    name = row["name"].ToString(),
                    sex = Convert.ToInt32(row["sex"]),
                    position = row["position"].ToString(),
                    age = Convert.ToInt32(row["age"]),
                    add_time = Convert.ToDateTime(row["add_time"]),
                    update_time = Convert.ToDateTime(row["update_time"]),
                    deleted = Convert.ToInt32(row["deleted"])
                });
            }
            Teacher model2 = list[0];
            return model2;
        }
        public int Add(Teacher model)
        {
            string sql = "insert into teacher(teacher_id,password,name,sex,position,age,add_time) " +
                "values (@teacher_id,@password,@name,@sex,@position,@age,@add_time)";
            //数组的初始化器
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@teacher_id",model.teacher_id),
                new SQLiteParameter("@password",Md5Helper.GetMd5(model.password)),
                new SQLiteParameter("@name",model.name),
                new SQLiteParameter("@sex",model.sex),
                new SQLiteParameter("@position",model.position),
                new SQLiteParameter("@age",model.age),
                new SQLiteParameter("@add_time",DateTime.Now)
            };

            //执行
            return SqliteHelper.Add(sql, ps);
        }

        /// <summary>
        /// 逻辑删除，返回-2则表示已经删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns>-2，已经删除</returns>
        public int Delete(Teacher model)
        {
            if (SelectById(model).deleted == 1)
            {
                //如果deleted==1，已经删除，返回-2
                return -2;
            }

            string sql = "update teacher set deleted=1 where id=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@id",model.id),
            };
            return SqliteHelper.Delete(sql, ps);
        }

        public int Update(Teacher model)
        {
            if (SelectById(model).deleted == 1)
            {
                //如果deleted==1，已经删除，返回-2
                return -2;
            }
            List<Object> obj = updateSQL(model);
            string sql = obj[0].ToString();
            List<SQLiteParameter> ps = (List<SQLiteParameter>)obj[1];

            return SqliteHelper.update(sql, ps.ToArray());
        }
        private List<Object> updateSQL(Teacher model)
        {
            List<SQLiteParameter> ps = new List<SQLiteParameter>();
            string sql = "update teacher set ";
            bool flag = false;
            if (model.password != null)
            {
                if (flag)
                {
                    sql += ",";
                }
                sql += "password=@password";
                ps.Add(new SQLiteParameter("@password", Md5Helper.GetMd5(model.password)));
                flag = true;
            }
            if (model.name != null)
            {
                if (flag)
                {
                    sql += ",";
                }
                sql += "name=@name";
                ps.Add(new SQLiteParameter("@name", model.name));
                flag = true;
            }
            if (model.sex != 0)
            {
                if (flag)
                {
                    sql += ",";
                }
                sql += "sex=@sex";
                ps.Add(new SQLiteParameter("@sex", model.sex));
                flag = true;
            }
            if (model.position != null)
            {
                if (flag)
                {
                    sql += ",";
                }
                sql += "position=@position";
                ps.Add(new SQLiteParameter("@position", model.position));
                flag = true;
            }
            if (model.age != 0)
            {
                if (flag)
                {
                    sql += ",";
                }
                sql += "age=@age";
                ps.Add(new SQLiteParameter("@age", model.age));
                flag = true;
            }



            if (flag)
            {
                sql += ",";
            }
            sql += "update_time=@update_time";
            ps.Add(new SQLiteParameter("@update_time", DateTime.Now));
            sql += " where id=@id";
            ps.Add(new SQLiteParameter("@id", model.id));
            List<Object> obj = new List<object>();
            obj.Add(sql);
            obj.Add(ps);
            return obj;
        }


        public List<Teacher> SelectAll()
        {
            //执行查询，获取数据
            DataTable table = SqliteHelper.Select("SELECT * FROM teacher where deleted=0");
            //构造数据集合
            List<Teacher> list = new List<Teacher>();
            //遍历数据表，将数据转存到集合中
            foreach (DataRow row in table.Rows)
            {
                list.Add(new Teacher()
                {
                    id = Convert.ToInt32(row["id"]),
                    teacher_id = Convert.ToInt32(row["teacher_id"]),
                    password = row["password"].ToString(),
                    name = row["name"].ToString(),
                    sex = Convert.ToInt32(row["sex"]),
                    position = row["position"].ToString(),
                    age = Convert.ToInt32(row["age"]),
                    add_time = Convert.ToDateTime(row["add_time"]),
                    update_time = Convert.ToDateTime(row["update_time"]),
                    deleted = Convert.ToInt32(row["deleted"])
                });
            }
            return list;
        }
    }
}
