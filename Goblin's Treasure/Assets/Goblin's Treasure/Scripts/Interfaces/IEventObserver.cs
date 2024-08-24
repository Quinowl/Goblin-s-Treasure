namespace GoblinsTreasure.Scripts.Events {

    public interface IEventObserver {

        public void ProcessEvents(EventData eventData);

    }
}