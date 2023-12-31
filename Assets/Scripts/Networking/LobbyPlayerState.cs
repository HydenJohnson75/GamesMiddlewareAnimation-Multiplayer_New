using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public struct LobbyPlayerState : INetworkSerializable, IEquatable<LobbyPlayerState>
{
    public ulong ClientId;
    public bool IsReady;

    public LobbyPlayerState(ulong clientId, bool isReady)
    {
        ClientId = clientId;
        IsReady = isReady;
    }

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref ClientId);
        serializer.SerializeValue(ref IsReady);
    }

    public bool Equals(LobbyPlayerState other)
    {
        return ClientId == other.ClientId && IsReady == other.IsReady;
    }
}
