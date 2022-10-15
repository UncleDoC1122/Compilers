package sapr_lr1;

import java.awt.List;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Scanner;
import java.util.Set;
import java.util.Stack;
import java.util.regex.Pattern;

public class Program {
	static String str = "";

	public static void main(String[] args) {
		try {
			Scanner sc = new Scanner(new File("D:\\A_labs_files\\ex1.txt"));
			while(sc.hasNextLine()) {
				str = str + sc.nextLine();
			}
			sc.close();

		} catch (FileNotFoundException e) {
			e.printStackTrace();
		}
		
		//делаем доп пробелы для всяких знаков
		str = str.replaceAll(";"," ; ");
		str = str.replaceAll("\\("," ( ");
		str = str.replaceAll("\\)"," ) ");
		str = str.replaceAll("\\{"," { ");
		str = str.replaceAll("\\}"," } ");
		str = str.replaceAll("\\++"," ++ ");
		str = str.replaceAll("\\--"," -- ");
		str = str.replaceAll("\\+="," += ");
		
		
		
		//делаем 1 пробел
		str = str.replaceAll("\\s+"," ");
		
		System.out.print("All lexems:    " + str);
		
		System.out.print("\n" + "====================================================================================" + "\n");
		
		String[] words = str.split(" ");
		// типы данных
		Map<String, String> Value = new HashMap<>();
		Value.put("int", "32-bit integer;1 ;Data type     ");
		Value.put("long", "64-bit integer;2 ;Data type     ");
		Value.put("string", "string of chars;3 ;Data type     ");
		// операции
		Value.put("=", "assign_operation;1 ;Operation     ");
		Value.put("+", "sum_operation;2 ;Operation     ");
		Value.put("-", "subtract_operation;3 ;Operation     ");
		Value.put("*", "multiply_operation;4 ;Operation     ");
		Value.put("/", "divide_operation;5 ;Operation     ");
		Value.put("+=", "add_amount_operation;6 ;Operation     ");
		Value.put("-=", "subtract_amount_operation;7 ;Operation     ");
		Value.put("==", "are_equal_operation;8 ;Operation     ");
		Value.put(">", "more_operation;9 ;Operation     ");
		Value.put("<", "less_operation;10;Operation     ");
		Value.put("++", "increment_operation;11;Operation     ");
		Value.put("--", "decrement_operation;12;Operation     ");
		// разделители, технические знаки
		Value.put(";", "semicolon;1 ;Delimeter     ");
		Value.put(":", "colon;2 ;Delimeter     ");
		Value.put("(", "open bracket;3 ;Delimeter     ");
		Value.put(")", "closing bracket;4 ;Delimeter     ");
		Value.put("{", "open brace;5 ;Delimeter     ");
		Value.put("}", "closing brace;6 ;Delimeter     ");
		// цикл по варианту
		Value.put("while", "while;1 ;Cycle         ");
		
		
		String stringInfo = "";
		String stringValue = "";
		String stringType = "";
		String stringId = "";
		
		int VariableId = 1;
		int ConstantId = 1;
		
		//Stack VariableStack = new Stack();
		ArrayList VariableList = new ArrayList();
		
		
		
		for (String word : words) {
			
			stringInfo = Value.get(word);
			boolean isNumeric = word.chars().allMatch( Character::isDigit );
			
			if(stringInfo != null) {
				String[] info = stringInfo.split(";");
				
				stringValue = info[0];
				stringId = info[1];
				stringType = info[2];
			}
			
			else if (isNumeric == true){
				stringType = "Constant      ";
				stringValue = "integer with value = " + word;
				stringId = Integer.toString(ConstantId) + " ";
				ConstantId ++;
			}
			// + проверка с регулярным выражением - в переменной нет знака или цифр
			else if (isNumeric != true && !Pattern.matches(".*\\W+.*",word) && !Pattern.matches(".*\\d+.*",word)){
				//Pattern pattern = Pattern.compile("\\W+");
				stringType = "Variable      ";
				stringValue = "variable <" + word + ">";
				stringId = Integer.toString(VariableId) + " ";
				VariableId ++;
				VariableList.add(word);
				
			}
			
			else {
				System.out.print("error");
				break;
			}
								
			System.out.print("lexem type: " + stringType + " lexem id: " + stringId + " value: " + stringValue + "\n");
			
			stringInfo = "";
			stringValue = "";
			stringType = "";
			stringId = "";
			
		}
		System.out.print("\n" + "====================================================================================" + "\n");
		
		Set<String> uniqueVariable = new HashSet<String>(VariableList);
		System.out.println("Variables: " + "\n" + uniqueVariable);
		

	}

}
