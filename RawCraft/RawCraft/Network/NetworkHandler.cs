using System;
using System.Net.Sockets;
using System.Threading;
using RawCraft.Network.Encryption;
using RawCraft.Network.Packets;

namespace RawCraft.Network
{
    class NetworkHandler // TODO: Make this not the worst thing ever
    {
        private EnhancedStream _stream;
        private byte _packetIDbuffer;
        private PlayerPositionLook _playerPositionLook;

        public void NetThread()
        {
            SessionIDRequest sessionID = new SessionIDRequest(Storage.Network.UserName, Storage.Network.Password);
            sessionID.SendRequest();

            SharedSecretGenerator sharedSecret = new SharedSecretGenerator(); //random byte[16] gen

            Timer positionUpdater = new Timer(PositionSender, null, Timeout.Infinite, 50); //create position updater

            Socket networkSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            networkSocket.Connect(Storage.Network.Server, Storage.Network.Port);
            _stream = new EnhancedStream(networkSocket);

            Handshake handshake = new Handshake(_stream);
            handshake.Send(Storage.Network.UserName, Storage.Network.Server, Storage.Network.Port); // connect

            Storage.Network.IsConnected = true;

            while (Storage.Network.IsConnected)
            {
                switch (_packetIDbuffer = (byte)_stream.ReadByte())
                {
                    case 0x00:
                        KeepAlive keepAlive = new KeepAlive(_stream);
                        break;
                    case 0x01:
                        LoginRequest loginRequest = new LoginRequest(_stream);
                        positionUpdater.Change(0, 50);
                        ClientSettings clientSettings = new ClientSettings(_stream);
                        clientSettings.Send();
                        break;
                    case 0x03:
                        ChatMessage chatMessage = new ChatMessage(_stream);
                        break;
                    case 0x04:
                        TimeUpdate timeUpdate = new TimeUpdate(_stream);
                        break;
                    case 0x05:
                        EntityEquipment entityEquipment = new EntityEquipment(_stream);
                        break;
                    case 0x06:
                        SpawnPosition spawnPosition = new SpawnPosition(_stream);
                        break;
                    case 0x08:
                        UpdateHealth updateHealth = new UpdateHealth(_stream);
                        break;
                    case 0x09:
                        RespawnPacket respawnPacket = new RespawnPacket(_stream);
                        break;
                    case 0x0D:
                        _playerPositionLook = new PlayerPositionLook(_stream);
                        break;
                    case 0x11:
                        UseBed useBed = new UseBed(_stream);
                        break;
                    case 0x12:
                        Animation animation = new Animation(_stream);
                        break;
                    case 0x14:
                        SpawnNamedEntity spawnNamedEntity = new SpawnNamedEntity(_stream);
                        break;
                    case 0x15:
                        SpawnDroppedItem spawnDroppedItem = new SpawnDroppedItem(_stream);
                        break;
                    case 0x16:
                        CollectItem collectItem = new CollectItem(_stream);
                        break;
                    case 0x17:
                        SpawnObjectVehicle spawnObjectVehicle = new SpawnObjectVehicle(_stream);
                        break;
                    case 0x18:
                        SpawnMob spawnMob = new SpawnMob(_stream);
                        break;
                    case 0x19:
                        SpawnPainting spawnPainting = new SpawnPainting(_stream);
                        break;
                    case 0x1A:
                        SpawnExperienceOrb spawnExperienceOrb = new SpawnExperienceOrb(_stream);
                        break;
                    case 0x1C:
                        EntityVelocity entityVelocity = new EntityVelocity(_stream);
                        break;
                    case 0x1D:
                        DestroyEntity destroyEntity = new DestroyEntity(_stream);
                        break;
                    case 0x1E:
                        Entity entity = new Entity(_stream);
                        break;
                    case 0x1F:
                        EntityRelativeMove entityRelativeMove = new EntityRelativeMove(_stream);
                        break;
                    case 0x20:
                        EntityLook entityLook = new EntityLook(_stream);
                        break;
                    case 0x21:
                        EntityLookRelativeMove entityLookRelativeMove = new EntityLookRelativeMove(_stream);
                        break;
                    case 0x22:
                        EntityTeleport entityTeleport = new EntityTeleport(_stream);
                        break;
                    case 0x23:
                        EntityHeadLook entityHeadLook = new EntityHeadLook(_stream);
                        break;
                    case 0x26:
                        EntityStatus entityStatus = new EntityStatus(_stream);
                        break;
                    case 0x27:
                        AttachEntity attachEntity = new AttachEntity(_stream);
                        break;
                    case 0x28:
                        EntityMetadata entityMetadata = new EntityMetadata(_stream);
                        break;
                    case 0x29:
                        EntityEffect entityEffect = new EntityEffect(_stream);
                        break;
                    case 0x2A:
                        RemoveEntityEffect removeEntityEffect = new RemoveEntityEffect(_stream);
                        break;
                    case 0x2B:
                        SetExperience setExperience = new SetExperience(_stream);
                        break;
                    case 0x33:
                        ChunkData mapChunk = new ChunkData(_stream);
                        break;
                    case 0x34:
                        MultiBlockChange multiBlockChange = new MultiBlockChange(_stream);
                        break;
                    case 0x35:
                        BlockChange blockChange = new BlockChange(_stream);
                        break;
                    case 0x36:
                        BlockAction blockAction = new BlockAction(_stream);
                        break;
                    case 0x37:
                        BlockBreakAnimation blockBreakAnimation = new BlockBreakAnimation(_stream);
                        break;
                    case 0x38:
                        MapChunkBulk mapChunkBulk = new MapChunkBulk(_stream);
                        break;
                    case 0x3C:
                        Explosion explosion = new Explosion(_stream);
                        break;
                    case 0x3D:
                        SoundParticleEffect soundParticleEffect = new SoundParticleEffect(_stream);
                        break;
                    case 0x3E:
                        NamedSoundEffect namedSoundEffect = new NamedSoundEffect(_stream);
                        break;
                    case 0x46:
                        ChangeGameState changeGameState = new ChangeGameState(_stream);
                        break;
                    case 0x47:
                        Thunderbolt thunderbolt = new Thunderbolt(_stream);
                        break;
                    case 0x64:
                        OpenWindow openWindow = new OpenWindow(_stream);
                        break;
                    case 0x65:
                        CloseWindow closeWindow = new CloseWindow(_stream);
                        break;
                    case 0x67:
                        SetSlot setSlot = new SetSlot(_stream);
                        break;
                    case 0x68:
                        SetWindowItems setWindowItems = new SetWindowItems(_stream);
                        break;
                    case 0x69:
                        UpdateWindowProperty updateWindowProperty = new UpdateWindowProperty(_stream);
                        break;
                    case 0x6A:
                        ConfirmTransaction confirmTransaction = new ConfirmTransaction(_stream);
                        break;
                    case 0x6B:
                        CreativeInventoryAction creativeInventoryAction = new CreativeInventoryAction(_stream);
                        break;
                    case 0x6C:
                        EnchantItem enchantItem = new EnchantItem(_stream);
                        break;
                    case 0x82:
                        UpdateSign updateSign = new UpdateSign(_stream);
                        break;
                    case 0x83:
                        ItemData itemData = new ItemData(_stream);
                        break;
                    case 0x84:
                        UpdateTileEntity updateTileEntity = new UpdateTileEntity(_stream);
                        break;
                    case 0xC8:
                        IncrementStatistic incrementStatistic = new IncrementStatistic(_stream);
                        break;
                    case 0xC9:
                        PlayerListItem playerListItem = new PlayerListItem(_stream);
                        break;
                    case 0xCA:
                        PlayerAbilities playerAbilities = new PlayerAbilities(_stream);
                        break;
                    case 0xCB:
                        TabComplete tabcomplete = new TabComplete(_stream);
                        break;
                    case 0xFA:
                        PluginMessage pluginMessage = new PluginMessage(_stream);
                        break;
                    case 0xFC:
                        EncryptionKeyResponse encryptionKeyResponse = new EncryptionKeyResponse(_stream);
                        encryptionKeyResponse.Get();
                        _stream = new AesStream(networkSocket, _stream, sharedSecret.Get);
                        ClientStatuses clientStatuses = new ClientStatuses(_stream);
                        clientStatuses.Send(0);
                        break;
                    case 0xFD:
                        EncryptionKeyRequest encryptionKeyRequest = new EncryptionKeyRequest(_stream, sharedSecret.Get, sessionID.GetID(), Storage.Network.UserName); //
                        encryptionKeyResponse = new EncryptionKeyResponse(_stream);
                        encryptionKeyResponse.Send(encryptionKeyRequest.GetEncSharedSecret(), encryptionKeyRequest.GetEncToken());
                        break;
                    case 0xFF:
                        positionUpdater = null;
                        DisconnectKick disconnectKick = new DisconnectKick(_stream);
                        networkSocket.Disconnect(false);
                        break;
                    default:
                        throw new Exception("We got a Unknown Packet (" + _packetIDbuffer + ")from the Server. This should not happen: Error in Packet parser");
                }
            }
        }

        private void PositionSender(object o)
        {
            if (_playerPositionLook != null)
                _playerPositionLook.Send();
        }
    }
}