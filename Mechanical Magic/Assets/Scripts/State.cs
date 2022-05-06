public enum State {
    Talking, Default, BananaPeeling, Pause
}

public static class StateManager {
    public static State ActiveState = State.Default;
    //public static State ActiveState;

    public static void SetState(State s) {
        ActiveState = s;
    }

    public static State GetState(){
        return ActiveState;
    }
}