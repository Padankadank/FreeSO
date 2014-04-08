﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSO.Simantics.engine;
using TSO.Files.utils;
using TSO.Simantics.engine.scopes;
using TSO.Simantics.engine.utils;

namespace TSO.Simantics.primitives
{
    public class VMChangeSuitOrAccessory : VMPrimitiveHandler {
        public override VMPrimitiveExitCode Execute(VMStackFrame context){
            var operand = context.GetCurrentOperand<VMChangeSuitOrAccessoryOperand>();
            var suit = VMMemory.GetSuit(context, operand.SuitScope, operand.SuitData);
            var avatar = (VMAvatar)context.Caller;

            if(suit == null){
                return VMPrimitiveExitCode.GOTO_TRUE;
            }

            if ((operand.Flags & VMChangeSuitOrAccessoryFlags.Remove) == VMChangeSuitOrAccessoryFlags.Remove)
            {
                avatar.Avatar.RemoveAccessory(suit);
            }
            else
            {
                avatar.Avatar.AddAccessory(suit);
            }

            return VMPrimitiveExitCode.GOTO_TRUE_NEXT_TICK;
        }
    }

    public class VMChangeSuitOrAccessoryOperand : VMPrimitiveOperand {

        public byte SuitData;
        public VMSuitScope SuitScope;
        public VMChangeSuitOrAccessoryFlags Flags;

        #region VMPrimitiveOperand Members
        public void Read(byte[] bytes)
        {
            using (var io = IoBuffer.FromBytes(bytes, ByteOrder.LITTLE_ENDIAN)){
                SuitData = io.ReadByte();
                SuitScope = (VMSuitScope)io.ReadByte();
                Flags = (VMChangeSuitOrAccessoryFlags)io.ReadUInt16();
            }
        }
        #endregion
    }

    [Flags]
    public enum VMChangeSuitOrAccessoryFlags
    {
        Remove = 1
    }
}
