public enum State {
    Talking, Default, BananaPeeling, Pause
}

public static class StateManager {
    public static State ActiveState = State.Default;
    public static void SetState(State s) {
        ActiveState = s;
    }
}