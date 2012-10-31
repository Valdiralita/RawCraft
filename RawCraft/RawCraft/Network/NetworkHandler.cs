using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using RawCraft.Network.Encryption;
using RawCraft.Network.Packets;
using RawCraft.Storage;

namespace RawCraft.Network
{
    class NetworkHandler
    {
        // TODO: Make this not the worst thing ever

        private EnhancedStream stream;
        private byte packetIDbuffer;
        private PlayerPositionLook playerPositionLook;

        public void NetThread()
        {
            if (Misc.Log == null)
                Misc.Log = new Logging();
            Misc.Log.Write("Network Thread running");

            SessionIDRequest sessionID = new SessionIDRequest(Storage.Network.UserName, Storage.Network.Password);
            sessionID.SendRequest();

            SharedSecretGenerator SharedSecret = new SharedSecretGenerator(); //random byte[16] gen

            Timer PositionUpdater = new Timer(new TimerCallback(NetworkSender), null, Timeout.Infinite, 50); //create position updater

            Socket NetworkSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            NetworkSocket.Connect(Storage.Network.Server, Storage.Network.Port);
            //stream = new NetworkStream(NetworkSocket);
            stream = new EnhancedStream(NetworkSocket);

            Handshake handshake = new Handshake(stream);
            handshake.Send(Storage.Network.UserName, Storage.Network.Server, Storage.Network.Port); // connect

            while (Storage.Misc.isConnected)
            {
                switch (packetIDbuffer = (byte)stream.ReadByte())
                {
                    case 0x00:
                        KeepAlive keepAlive = new KeepAlive(stream);
                        break;
                    case 0x01:
                        LoginRequest loginRequest = new LoginRequest(stream);
                        PositionUpdater.Change(0, 500);
                        ClientSettings clientSettings = new ClientSettings(stream);
                        clientSettings.Send();
                        break;
                    case 0x03:
                        ChatMessage chatMessage = new ChatMessage(stream);
                        break;
                    case 0x04:
                        TimeUpdate timeUpdate = new TimeUpdate(stream);
                        break;
                    case 0x05:
                        EntityEquipment entityEquipment = new EntityEquipment(stream);
                        break;
                    case 0x06:
                        SpawnPosition spawnPosition = new SpawnPosition(stream);
                        break;
                    case 0x08:
                        UpdateHealth updateHealth = new UpdateHealth(stream);
                        break;
                    case 0x09:
                        RespawnPacket respawnPacket = new RespawnPacket(stream);
                        break;
                    case 0x0D:
                        playerPositionLook = new PlayerPositionLook(stream);
                        break;
                    case 0x11:
                        UseBed useBed = new UseBed(stream);
                        break;
                    case 0x12:
                        Animation animation = new Animation(stream);
                        break;
                    case 0x14:
                        SpawnNamedEntity spawnNamedEntity = new SpawnNamedEntity(stream);
                        break;
                    case 0x15:
                        SpawnDroppedItem spawnDroppedItem = new SpawnDroppedItem(stream);
                        break;
                    case 0x16:
                        CollectItem collectItem = new CollectItem(stream);
                        break;
                    case 0x17:
                        SpawnObjectVehicle spawnObjectVehicle = new SpawnObjectVehicle(stream);
                        break;
                    case 0x18:
                        SpawnMob spawnMob = new SpawnMob(stream);
                        break;
                    case 0x19:
                        SpawnPainting spawnPainting = new SpawnPainting(stream);
                        break;
                    case 0x1A:
                        SpawnExperienceOrb spawnExperienceOrb = new SpawnExperienceOrb(stream);
                        break;
                    case 0x1C:
                        EntityVelocity entityVelocity = new EntityVelocity(stream);
                        break;
                    case 0x1D:
                        DestroyEntity destroyEntity = new DestroyEntity(stream);
                        break;
                    case 0x1E:
                        Entity entity = new Entity(stream);
                        break;
                    case 0x1F:
                        EntityRelativeMove entityRelativeMove = new EntityRelativeMove(stream);
                        break;
                    case 0x20:
                        EntityLook entityLook = new EntityLook(stream);
                        break;
                    case 0x21:
                        EntityLookRelativeMove entityLookRelativeMove = new EntityLookRelativeMove(stream);
                        break;
                    case 0x22:
                        EntityTeleport entityTeleport = new EntityTeleport(stream);
                        break;
                    case 0x23:
                        EntityHeadLook entityHeadLook = new EntityHeadLook(stream);
                        break;
                    case 0x26:
                        EntityStatus entityStatus = new EntityStatus(stream);
                        break;
                    case 0x27:
                        AttachEntity attachEntity = new AttachEntity(stream);
                        break;
                    case 0x28:
                        EntityMetadata entityMetadata = new EntityMetadata(stream);
                        break;
                    case 0x29:
                        EntityEffect entityEffect = new EntityEffect(stream);
                        break;
                    case 0x2A:
                        RemoveEntityEffect removeEntityEffect = new RemoveEntityEffect(stream);
                        break;
                    case 0x2B:
                        SetExperience setExperience = new SetExperience(stream);
                        break;
                    case 0x33:
                        MapChunk mapChunk = new MapChunk(stream);
                        break;
                    case 0x34:
                        MultiBlockChange multiBlockChange = new MultiBlockChange(stream);
                        break;
                    case 0x35:
                        BlockChange blockChange = new BlockChange(stream);
                        break;
                    case 0x36:
                        BlockAction blockAction = new BlockAction(stream);
                        break;
                    case 0x37:
                        BlockBreakAnimation blockBreakAnimation = new BlockBreakAnimation(stream);
                        break;
                    case 0x38:
                        MapChunkBulk mapChunkBulk = new MapChunkBulk(stream);
                        break;
                    case 0x3C:
                        Explosion explosion = new Explosion(stream);
                        break;
                    case 0x3D:
                        SoundParticleEffect soundParticleEffect = new SoundParticleEffect(stream);
                        break;
                    case 0x3E:
                        NamedSoundEffect namedSoundEffect = new NamedSoundEffect(stream);
                        break;
                    case 0x46:
                        ChangeGameState changeGameState = new ChangeGameState(stream);
                        break;
                    case 0x47:
                        Thunderbolt thunderbolt = new Thunderbolt(stream);
                        break;
                    case 0x64:
                        OpenWindow openWindow = new OpenWindow(stream);
                        break;
                    case 0x65:
                        CloseWindow closeWindow = new CloseWindow(stream);
                        break;
                    case 0x67:
                        SetSlot setSlot = new SetSlot(stream);
                        break;
                    case 0x68:
                        SetWindowItems setWindowItems = new SetWindowItems(stream);
                        break;
                    case 0x69:
                        UpdateWindowProperty updateWindowProperty = new UpdateWindowProperty(stream);
                        break;
                    case 0x6A:
                        ConfirmTransaction confirmTransaction = new ConfirmTransaction(stream);
                        break;
                    case 0x6B:
                        CreativeInventoryAction creativeInventoryAction = new CreativeInventoryAction(stream);
                        break;
                    case 0x6C:
                        EnchantItem enchantItem = new EnchantItem(stream);
                        break;
                    case 0x82:
                        UpdateSign updateSign = new UpdateSign(stream);
                        break;
                    case 0x83:
                        ItemData itemData = new ItemData(stream);
                        break;
                    case 0x84:
                        UpdateTileEntity updateTileEntity = new UpdateTileEntity(stream);
                        break;
                    case 0xC8:
                        IncrementStatistic incrementStatistic = new IncrementStatistic(stream);
                        break;
                    case 0xC9:
                        PlayerListItem playerListItem = new PlayerListItem(stream);
                        break;
                    case 0xCA:
                        PlayerAbilities playerAbilities = new PlayerAbilities(stream);
                        break;
                    case 0xCB:
                        TabComplete tabcomplete = new TabComplete(stream);
                        break;
                    case 0xFA:
                        PluginMessage pluginMessage = new PluginMessage(stream);
                        break;
                    case 0xFC:
                        EncryptionKeyResponse encryptionKeyResponse = new EncryptionKeyResponse(stream);
                        encryptionKeyResponse.Get();
                        stream = new AesStream(NetworkSocket, stream, SharedSecret.Get);
                        ClientStatuses clientStatuses = new ClientStatuses(stream);
                        clientStatuses.Send(0);
                        break;
                    case 0xFD:
                        EncryptionKeyRequest encryptionKeyRequest = new EncryptionKeyRequest(stream, SharedSecret.Get, sessionID.GetID(), Storage.Network.UserName); //
                        encryptionKeyResponse = new EncryptionKeyResponse(stream);
                        encryptionKeyResponse.Send(encryptionKeyRequest.GetEncSharedSecret(), encryptionKeyRequest.GetEncToken());
                        break;
                    case 0xFF:
                        PositionUpdater = null;
                        DisconnectKick disconnectKick = new DisconnectKick(stream, NetworkSocket);
                        break;
                    default:
                        Misc.Log.Write("We got a Unknown Packet (" + packetIDbuffer + ")from the Server. This should not happen: Error in Packet parser");
                        throw new Exception("We got a Unknown Packet (" + packetIDbuffer + ")from the Server. This should not happen: Error in Packet parser");
                }
            }
            Misc.Log.Write("Your connection to the server has been terminated.");
        }

        private void NetworkSender(object o)
        {
            // doesnt work
            
            if (playerPositionLook != null)
                playerPositionLook.Send();
        }
    }
}