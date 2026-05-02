bool IsPalindrome(int x)
{
	if (x < 0) return false;

	string s = x.ToString();

	int left = 0;
	int right = s.Length - 1;

	while (left < right)
	{
		if (s[left] != s[right])
		{
			return false;
		}
		left++;
		right--;
	}
	return true;
}

// Просто проверяем
Console.WriteLine(IsPalindrome(121));   // True
Console.WriteLine(IsPalindrome(-121));  // False
Console.WriteLine(IsPalindrome(10));    // False