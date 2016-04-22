using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneNET.Api.Entity
{
    /// <summary>
    /// 设备云上的二进制数据的描述信息 在查询设备详情时会用到
    /// @author Philo
    /// </summary>
    public class BinaryInfo
    {
        /// <summary>
        /// 二进制数据的大小
        /// </summary>
        private int size;

        /// <summary>
        /// 二进制数据产生的时间，时间格式必须2015-10-10T15:10:10
        /// </summary>
        private String at;
        /// <summary>
        /// 本二进制数据在设备云中的索引字符串
        /// </summary>
        private String index;
        /// <summary>
        /// 本二进制数据的描述，可以为整数、字符串、JSON对象等复杂数据结构
        /// </summary>
        private Object desc;

        public int getSize()
        {
            return size;
        }

        public void setSize(int size)
        {
            this.size = size;
        }

        public String getAt()
        {
            return at;
        }

        public void setAt(String at)
        {
            this.at = at;
        }

        public String getIndex()
        {
            return index;
        }

        public void setIndex(String index)
        {
            this.index = index;
        }

        public Object getDesc()
        {
            return desc;
        }

        public void setDesc(Object desc)
        {
            this.desc = desc;
        }

        public String toString()
        {
            return "BinaryData [size=" + size + ", at=" + at + ", index=" + index + ", desc=" + desc
                    + "]";
        }

        public int hashCode()
        {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((at == null) ? 0 : at.GetHashCode());
            result = prime * result + ((desc == null) ? 0 : desc.GetHashCode());
            result = prime * result + ((index == null) ? 0 : index.GetHashCode());
            result = prime * result + size;
            return result;
        }


        public Boolean equals(Object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            BinaryInfo other = (BinaryInfo)obj;
            if (at == null)
            {
                if (other.at != null)
                    return false;
            }
            else if (!at.Equals(other.at))
                return false;
            if (desc == null)
            {
                if (other.desc != null)
                    return false;
            }
            else if (!desc.Equals(other.desc))
                return false;
            if (index == null)
            {
                if (other.index != null)
                    return false;
            }
            else if (!index.Equals(other.index))
                return false;
            if (size != other.size)
                return false;
            return true;
        }
    }
}