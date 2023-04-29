Solution s = new Solution();
Console.WriteLine(s.IsPalindrome("racecar"));

public class Solution {
    public bool IsPalindrome(string s) {
        char[] array = s.ToCharArray();
        
        int left = 0;
        int right = s.Length - 1;

        while (left < right) {
            if (array[left] != array[right]) {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
}