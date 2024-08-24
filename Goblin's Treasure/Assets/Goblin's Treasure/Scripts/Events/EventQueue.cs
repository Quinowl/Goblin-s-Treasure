using System.Collections.Generic;
using UnityEngine;

namespace GoblinsTreasure.Scripts.Events {

    public class EventQueue : MonoBehaviour {

        private struct RemoveData {

            public EventIds EventId;
            public IEventObserver EventObserver;

            public RemoveData(EventIds eventId, IEventObserver eventObserver) {

                EventId = eventId;
                EventObserver = eventObserver;
            }
        }

        private bool _isProcessingEvents;
        private List<RemoveData> _pendingObserversToUnsubscribe;

        private Queue<EventData> _currentEvents;
        private Queue<EventData> _nextEvents;

        private Dictionary<EventIds, List<IEventObserver>> _eventIdToObservers;

        private void Awake() {

            _pendingObserversToUnsubscribe = new List<RemoveData>();
            _currentEvents = new Queue<EventData>();
            _nextEvents = new Queue<EventData>();
            _eventIdToObservers = new Dictionary<EventIds, List<IEventObserver>>();
        }

        private void LateUpdate() => ProcessAllEvents();

        public void Subscribe(EventIds eventId, IEventObserver observer) {

            if (!_eventIdToObservers.TryGetValue(eventId, out var observers)) observers = new List<IEventObserver>();

            observers.Add(observer);
            _eventIdToObservers[eventId] = observers;
        }

        public void Unsubscribe(EventIds eventId, IEventObserver observer) {

            if (_isProcessingEvents) {

                RemoveData removeData = new RemoveData(eventId, observer);
                _pendingObserversToUnsubscribe.Add(removeData);
                return;
            }

            DoUnsubscribe(eventId, observer);

        }

        private void DoUnsubscribe(EventIds eventId, IEventObserver observer) => _eventIdToObservers[eventId].Remove(observer);

        public void EnqueueEvent(EventData eventData) => _nextEvents.Enqueue(eventData);

        private void ProcessAllEvents() {

            var tempCurrentEvents = _currentEvents;
            _currentEvents = _nextEvents;
            _nextEvents = tempCurrentEvents;

            foreach (var currentEvent in _currentEvents) ProcessEvent(currentEvent);

            _currentEvents.Clear();
        }

        private void ProcessEvent(EventData eventData) {

            _isProcessingEvents = true;

            if (_eventIdToObservers.TryGetValue(eventData.EventId, out var eventObservers)) {

                foreach (var observer in eventObservers) observer?.ProcessEvents(eventData);

            }

            _isProcessingEvents = false;

            UnsubscribePendingObservers();
        }

        private void UnsubscribePendingObservers() {

            foreach (var removeData in _pendingObserversToUnsubscribe) DoUnsubscribe(removeData.EventId, removeData.EventObserver);

            _pendingObserversToUnsubscribe.Clear();
        }
    }
}