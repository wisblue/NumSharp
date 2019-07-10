﻿/*
This file was generated by template ../NDArray.Elementwise.tt
In case you want to do some changes do the following 

1 ) adapt the tt file
2 ) execute powershell file "GenerateCode.ps1" on root level

*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Numerics;
using NumSharp.Shared;
using System.Threading.Tasks;

namespace NumSharp.Backends
{
    public partial class DefaultEngine
    {
        public override NDArray Multiply(NDArray x, NDArray y)
        {
            /// following code is for determine if scalar or not
            /// also for determine result
            int scalarNo = !(x.ndim == 0 || y.ndim == 0) ? 0 : -1;

            if (scalarNo == 0)
            {
                if (!Enumerable.SequenceEqual(x.shape, y.shape))
                {
                    throw new IncorrectShapeException();
                }
            }
            else
            {
                if (x.ndim == 0)
                    scalarNo = 1;
                else
                    scalarNo = 2;
            }

            NDArray result = null;

            switch (scalarNo)
            {
                case 1:
                    {
                        result = new NDArray(y.dtype, y.shape);
                        break;
                    }
                case 2:
                    {
                        result = new NDArray(x.dtype, x.shape);
                        break;
                    }
                default:
                    {
                        result = new NDArray(x.dtype, x.shape);
                        break;
                    }
            }

            var np1SysArr = x.Array;
            var np2SysArr = y.Array;
            var np3SysArr = result.Array;

            switch (np3SysArr)
            {
                case byte[] resArr:
                    {
                        var np1Array = np1SysArr as byte[];
                        var np2Array = np2SysArr as byte[];
                        np1Array = (np1Array == null) ? x.CloneData<byte>() : np1Array;
                        np2Array = (np2Array == null) ? y.CloneData<byte>() : np2Array;

                        if (scalarNo == 0)
                        {
                            Parallel.For(0, np3SysArr.Length, idx =>
                            {
                                resArr[idx] = (byte)(np1Array[idx] * np2Array[idx]);
                            });
                        }
                        else if (scalarNo == 1)
                        {
                            var scalar = x.CloneData<int>()[0];
                            for (int idx = 0; idx < np3SysArr.Length; idx++)
                                resArr[idx] = (byte)(scalar * np2Array[idx]);
                        }
                        else if (scalarNo == 2)
                        {
                            switch(Type.GetTypeCode(y.dtype))
                            {
                                case TypeCode.Int32:
                                    {
                                        var scalar = y.CloneData<int>()[0];
                                        for (int idx = 0; idx < np3SysArr.Length; idx++)
                                            resArr[idx] = (byte)(np1Array[idx] * scalar);
                                    }
                                    break;
                                case TypeCode.Single:
                                    {
                                        var scalar = y.CloneData<float>()[0];
                                        for (int idx = 0; idx < np3SysArr.Length; idx++)
                                            resArr[idx] = (byte)(np1Array[idx] * scalar);
                                    }
                                    break;
                                default:
                                    throw new NotImplementedException($"Default.Multiply {y.dtype}");
                            }
                        }
                        break;
                    }

                case ushort[] resArr:
                    {
                        var np1Array = np1SysArr as ushort[];
                        var np2Array = np2SysArr as ushort[];
                        np1Array = (np1Array == null) ? x.CloneData<ushort>() : np1Array;
                        np2Array = (np2Array == null) ? y.CloneData<ushort>() : np2Array;

                        if (scalarNo == 0)
                        {
                            Parallel.For(0, np3SysArr.Length, idx =>
                            {
                                resArr[idx] = (ushort)(np1Array[idx] * np2Array[idx]);
                            });
                        }
                        else if (scalarNo == 1)
                        {
                            var scalar = x.CloneData<int>()[0];
                            for (int idx = 0; idx < np3SysArr.Length; idx++)
                                resArr[idx] = (ushort)(scalar * np2Array[idx]);
                        }
                        else if (scalarNo == 2)
                        {
                            var scalar = y.CloneData<int>()[0];
                            for (int idx = 0; idx < np3SysArr.Length; idx++)
                                resArr[idx] = (ushort)(np1Array[idx] * scalar);
                        }
                        break;
                    }

                case int[] resArr:
                    {
                        var np1Array = np1SysArr as int[];
                        var np2Array = np2SysArr as int[];
                        np1Array = (np1Array == null) ? x.CloneData<int>() : np1Array;
                        np2Array = (np2Array == null) ? y.CloneData<int>() : np2Array;

                        if (scalarNo == 0)
                        {
                            Parallel.For(0, np3SysArr.Length, idx =>
                            {
                                resArr[idx] = np1Array[idx] * np2Array[idx];
                            });
                        }
                        else if (scalarNo == 1)
                        {
                            var scalar = x.CloneData<int>()[0];
                            for (int idx = 0; idx < np3SysArr.Length; idx++)
                                resArr[idx] = scalar * np2Array[idx];
                        }
                        else if (scalarNo == 2)
                        {
                            var scalar = y.CloneData<int>()[0];
                            for (int idx = 0; idx < np3SysArr.Length; idx++)
                                resArr[idx] = np1Array[idx] * scalar;
                        }
                        break;
                    }

                case System.Int64[] resArr:
                    {
                        System.Int64[] np1Array = np1SysArr as System.Int64[];
                        System.Int64[] np2Array = np2SysArr as System.Int64[];
                        np1Array = (np1Array == null) ? x.CloneData<System.Int64>() : np1Array;
                        np2Array = (np2Array == null) ? y.CloneData<System.Int64>() : np2Array;

                        if (scalarNo == 0)
                            for (int idx = 0; idx < np3SysArr.Length; idx++)
                                resArr[idx] = np1Array[idx] * np2Array[idx];
                        else if (scalarNo == 1)
                        {
                            System.Int64 scalar = x.CloneData<System.Int64>()[0];
                            for (int idx = 0; idx < np3SysArr.Length; idx++)
                                resArr[idx] = scalar * np2Array[idx];
                        }
                        else if (scalarNo == 2)
                        {
                            System.Int64 scalar = y.CloneData<System.Int64>()[0];
                            for (int idx = 0; idx < np3SysArr.Length; idx++)
                                resArr[idx] = np1Array[idx] * scalar;
                        }
                        break;
                    }

                case float[] resArr:
                    {
                        var np1Array = np1SysArr as float[];
                        var np2Array = np2SysArr as float[];
                        np1Array = (np1Array == null) ? x.CloneData<float>() : np1Array;
                        np2Array = (np2Array == null) ? y.CloneData<float>() : np2Array;

                        if (scalarNo == 0)
                        {
                            Parallel.For(0, np3SysArr.Length, idx =>
                            {
                                resArr[idx] = np1Array[idx] * np2Array[idx];
                            });
                        }
                        else if (scalarNo == 1)
                        {
                            var scalar = x.CloneData<float>()[0];
                            Parallel.For(0, np3SysArr.Length, idx =>
                            {
                                resArr[idx] = scalar * np2Array[idx];
                            });
                        }
                        else if (scalarNo == 2)
                        {
                            var scalar = y.CloneData<float>()[0];
                            Parallel.For(0, np3SysArr.Length, idx =>
                            {
                                resArr[idx] = np1Array[idx] * scalar;
                            });
                        }
                        break;
                    }

                case System.Double[] resArr:
                    {
                        System.Double[] np1Array = np1SysArr as System.Double[];
                        System.Double[] np2Array = np2SysArr as System.Double[];
                        np1Array = (np1Array == null) ? x.CloneData<System.Double>() : np1Array;
                        np2Array = (np2Array == null) ? y.CloneData<System.Double>() : np2Array;

                        if (scalarNo == 0)
                            for (int idx = 0; idx < np3SysArr.Length; idx++)
                                resArr[idx] = np1Array[idx] * np2Array[idx];
                        else if (scalarNo == 1)
                        {
                            System.Double scalar = x.CloneData<System.Double>()[0];
                            for (int idx = 0; idx < np3SysArr.Length; idx++)
                                resArr[idx] = scalar * np2Array[idx];
                        }
                        else if (scalarNo == 2)
                        {
                            System.Double scalar = y.CloneData<System.Double>()[0];
                            for (int idx = 0; idx < np3SysArr.Length; idx++)
                                resArr[idx] = np1Array[idx] * scalar;
                        }
                        break;
                    }

                case System.Numerics.Complex[] resArr:
                    {
                        System.Numerics.Complex[] np1Array = np1SysArr as System.Numerics.Complex[];
                        System.Numerics.Complex[] np2Array = np2SysArr as System.Numerics.Complex[];
                        np1Array = (np1Array == null) ? x.CloneData<System.Numerics.Complex>() : np1Array;
                        np2Array = (np2Array == null) ? y.CloneData<System.Numerics.Complex>() : np2Array;

                        if (scalarNo == 0)
                            for (int idx = 0; idx < np3SysArr.Length; idx++)
                                resArr[idx] = np1Array[idx] * np2Array[idx];
                        else if (scalarNo == 1)
                        {
                            System.Numerics.Complex scalar = x.CloneData<System.Numerics.Complex>()[0];
                            for (int idx = 0; idx < np3SysArr.Length; idx++)
                                resArr[idx] = scalar * np2Array[idx];
                        }
                        else if (scalarNo == 2)
                        {
                            System.Numerics.Complex scalar = y.CloneData<System.Numerics.Complex>()[0];
                            for (int idx = 0; idx < np3SysArr.Length; idx++)
                                resArr[idx] = np1Array[idx] * scalar;
                        }
                        break;
                    }

                /*case System.Numerics.Quaternion[] resArr : 
				{
				    System.Numerics.Quaternion[] np1Array = np1SysArr as System.Numerics.Quaternion[];
				    System.Numerics.Quaternion[] np2Array = np2SysArr as System.Numerics.Quaternion[];
				    np1Array = (np1Array == null) ? np1.Storage.CloneData<System.Numerics.Quaternion>() : np1Array;
				    np2Array = (np2Array == null) ? np2.Storage.CloneData<System.Numerics.Quaternion>() : np2Array;

				    if (scalarNo == 0 )
				        for( int idx = 0; idx < np3SysArr.Length;idx++)
				            resArr[idx] = np1Array[idx] * np2Array[idx];
				    else if (scalarNo == 1 )
				    {
				        System.Numerics.Quaternion scalar = np1.Storage.CloneData<System.Numerics.Quaternion>()[0];
				        for( int idx = 0; idx < np3SysArr.Length;idx++)
				            resArr[idx] = scalar * np2Array[idx];
				    }
				    else if (scalarNo == 2 )
				    {
				        System.Numerics.Quaternion scalar = np2.Storage.CloneData<System.Numerics.Quaternion>()[0];
				        for( int idx = 0; idx < np3SysArr.Length;idx++)
				            resArr[idx] = np1Array[idx] * scalar;
				    }
				    break;
				}*/
                default:
                    {
                        throw new IncorrectTypeException();
                    }
            }

            return result;
        }
    }
}

