public class GeneralParams{
    public static float scale = 0.1f;
    public static float interval_time = 1f;
}
public class RoadParams{
    public static float meter2feet = 5280f / 1609.344f;
    public static float mile2feet = 5280f;
    public static float road_len_5 = (215.51f - 100.93f) * mile2feet * GeneralParams.scale;
    public static float road_len_90 = (25.37f - 1.94f) * mile2feet * GeneralParams.scale;
    public static float road_len_405 = (30.32f - 0f) * mile2feet * GeneralParams.scale;
    public static float road_len_520 = (12.83f - 0f) * mile2feet * GeneralParams.scale;
	public static float road_width = 12f * GeneralParams.scale;
    public static float road_5_start_milespost = 100.93f * mile2feet * GeneralParams.scale;
    public static float road_405_start_milespost = 0f;
}

public class CarParams{
    public static float min_safe_time = 3f;
    public static float max_safe_time = 5f;
    public static float car_witdh = 5f * GeneralParams.scale;
    public static float car_length = 9.84252f * GeneralParams.scale;
    public static float max_car_velocity = 60000 / 60 / 60f * RoadParams.meter2feet * GeneralParams.scale;
	public static float initial_car_velocity = 50f * GeneralParams.scale;
    public static float init_car_probability_denominator = 24 * 60 * 60 / GeneralParams.interval_time;
}

class Tag {
    public static string normal_car = "normal_car";
}