   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.Manager   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     � Title$  Manager��5   	   $	��450��6   $	��800��6&    � 	Resources 5	       	  style �� 
TargetType �� Property �� Value��%  &	        �� 5
   
   " ��5      .�5   
   ��  � ��$ 16(�5      �� 5   
    � ��$ MV Boli)�5      �� 5   
    � ��$ Normal"�5      �� 5   
    � ��$ 30��5      �� 5   
    � ��$	 100��5      5      5      .��5      � .+�5   
   �� .@�5      �� $��Guest Requests��6   .��5      �� -   5        $��GuestRequests��5       �� View 5      �� 5      .P�5      �� $	��Key��6-    �� DisplayMemberBinding 6:   �� *GuestRequestKey+�� 5      $
��Name��6-    6;   �� *	FirstName+�� 5       $��	Last Name��6-    6@   �� *
LastName+�� 5!      $��Email��6-    6<   �� *Email+�� 5"      $��Requirement Status��6-    6I   �� *RequirementStatus+�� 5#      $��Registration Date��6-    6H   �� *RegistrationDate+�� 5$      $��
Entry Date��6-    6A   �� *	EntryDate+�� 5%      $��Release Date��6-    6C   �� *ReleaseDate+�� 5&      $
��Area��6-    6;   �� *Area+�� 5'      $��Hosting Unit Type��6-    6H   �� *HostingUnitType+�� 5(      $��Num Of Adults��6-    6D   �� *NumOfAdults+�� 5)      $��Num Of Kids��6-    6B   �� *	NumOfKids+�� 5*      $
��Pool��6-    6;   �� *Pool+�� 5+      $��Jacuzzi��6-    6>   �� *	Jacuzzi+�� 5,      $��Porch��6-    6<   �� *Porch+�� 5-      $��Children Attractions��6-    6K   �� *ChildrenAttractions+�� 5.      $
��Food��6-    6;   �� *Food+5/      51      52      �� 53      $��Hosts��6   .��54      �� -   5        $��Hosts��54       55      �� 56      .P�57      �� $	��Key��6-    6:   �� *	HostKey+�� 58      $
��Name��6-    6;   �� *	FirstName+�� 59      $��	Last Name��6-    6@   �� *
LastName+�� 5:      $��Phone Number��6-    6C   �� *PhoneNumber+�� 5;      $��Email��6-    6<   �� *Email+�� 5<      $��Bank Account Number��6-    6J   �� *BankAccountNumber+�� 5=      $��Collection Clearance��6-    6K   �� *CollectionClearance+5>      5@      5A      �� 5B      $��Hosting Units��6   .��5C      �� -   5        $��HostingUnits��5C       5D      �� 5E      .P�5F      �� $	��Key��6-    6:   �� *HostingUnitKey+�� 5G      $
��Name��6-    6;   �� *HostingUnitName+�� 5H      $��	Owner Key��6-    6@   �� *Owner.HostKey+�� 5I      $��	Host Name��6-    6@   �� *Owner.FirstName+�� 5J      $
��Area��6-    6;   �� *Area+�� 5K      $��Hosting Unit Type��6-    6H   �� *HostingUnitType+�� 5L      $
��Pool��6-    6;   �� *Pool+�� 5M      $��Jacuzzi��6-    6>   �� *	Jacuzzi+�� 5N      $��Porch��6-    6<   �� *Porch+�� 5O      $��Children Attractions��6-    6K   �� *ChildrenAttractions+�� 5P      $
��Food��6-    6;   �� *Food+�� 5Q      $
��Beds��6-    6;   �� *Beds+5R      5T      5U      �� 5V      $��Orders��6   .��5W      �� -   5        $��Orders��5W       5X      �� 5Y      .P�5Z      �� $	��Key��6-    6:   �� *
OrderKey+�� 5[      $��Guest Request Key��6-    6H   �� *GuestRequestKey+�� 5\      $��Hosting Unit Key��6-    6G   �� *HostingUnitKey+�� 5]      $��Order Status��6-    6C   �� *Status+�� 5^      $��Create Date��6-    6B   �� *
CreateDate+�� 5_      $��
Order Date��6-    6A   �� *	OrderDate+5`      5b      5c      �� 5d      $��Commissions��6   .��5e      � $��1,20,6,5q�6   .+�5f      �� -   5         ��Name$ Commissions��5f      $#��Press to show your commission��63   $
��Left=�6[   $��
216,81,0,0q�6v   $	��Top=�6�   $	��320��6�   $��57��6�   $��MV Boli)�6�   $��20(�6�   5h      5i      �� 5j      $��Search��6   .��5k      � .+�5l      �� -   5        $ GuestRequestByArea��5l      $��Guest Request By Area��6;   $
��Left=�6[   $��	33,50,0,0q�6v   $	��Top=�6�   $	��673��6�   $��MV Boli)�6�   $��40(�6�   $��70��6�   6�   �� 5m      -   5        $ GuestRequestByNumOfGuests��5m      $$��Guest Request By Num Of Guests��6B   $
��Left=�6k   $��
33,139,0,0q�6�   $	��Top=�6�   $	��673��6�   $��MV Boli)�6�   $��40(�6�   $��70��6�   6�   �� 5n      -   5        $ HostsByNumOfHostingUnits��5n      $#��Hosts By Num Of Hosting Units��6A   $
��Left=�6i   $��
33,226,0,0q�6�   $	��Top=�6�   $	��673��6�   $��MV Boli)�6�   $��40(�6�   $��70��6�   6�   �� 5o      -	   5        $ HostingUnitsByArea��5o      $��Hosting Units By Area��6;   $
��Left=�6[   $��
33,315,0,0q�6v   $	��Top=�6�   $	��673��6�   $��MV Boli)�6�   $��40(�6�   $��70��6�   6�   5p      5q      5r      5s      5t      