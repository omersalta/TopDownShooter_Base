namespace _Scripts.Items.InventoryItems
{
    public abstract class AttachmentBase
    {
        public abstract bool TryAttach(AttacmentConfigScriptableObject _attacmentConfig);
        
        //TODO OnDropAttachment
    }
}