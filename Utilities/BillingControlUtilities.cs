using DataAcessLayer.Contracts;
using DataAcessLayer.Repositories;
using DomainModel.Contracts;
using DomainModel.Helpers;
using DomainModel.Models;
using ExamTracker.Common;
using ExamTracker.CustomControls;
using ExamTracker.Helpers;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExamTracker.Utilities;

public class BillingControlUtilities
{
	private readonly IInvoiceRepository _invoiceRepository;
	private readonly ISessionService _sessionService;
	private readonly IClientRepository _clientRepository;
	private readonly ICacheService _cacheService;
	private readonly IMessageService _messageService;
	private ErrorMessages _errorMessages;
	private readonly ILog log = LogManager.GetLogger(typeof(BillingControlUtilities));


	public BillingControlUtilities(IInvoiceRepository invoiceRepository, ISessionService sessionService,
		IClientRepository clientRepository, ICacheService cacheService,
		IMessageService messageService)
	{
		_invoiceRepository = invoiceRepository;
		_sessionService = sessionService;
		_clientRepository = clientRepository;
		_cacheService = cacheService;
		_errorMessages = LanguageHelper.Localization.ErrorMessages;
		_messageService = messageService;
	}

	public static string GenerateInvoiceNumber()
	{
		int numberId = Math.Abs(Guid.NewGuid().GetHashCode() % 9000) + 1000;
		string currYear = DateTime.Now.Year.ToString();
		return $"{numberId}/EXTR/{currYear}";
	}

	public static int GenerateUniqueIdentifier()
	{
		return Math.Abs(Guid.NewGuid().GetHashCode());
	}

	public void CustomizeGridAppearance(DataGridView table)
	{
		table.AutoGenerateColumns = false;

		DataGridViewColumn[] columns = new DataGridViewColumn[4];

		columns[0] = new DataGridViewTextBoxColumn() { DataPropertyName = "InvoiceNumber", HeaderText = "Invoice Number" };
		columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

		columns[1] = new DataGridViewImageColumn() { DataPropertyName = "picture", HeaderText = "" };
		columns[1].Width = 30;
		columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

		columns[2] = new DataGridViewTextBoxColumn() { DataPropertyName = "Is Paid?", HeaderText = "Is Paid?" };
		columns[2].Width = 40;
		columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

		columns[3] = new DataGridViewTextBoxColumn() { DataPropertyName = "Buyer", HeaderText = "Client" };
		columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


		table.RowHeadersVisible = false;
		table.Columns.Clear();
		table.Columns.AddRange(columns);
	}

	public void ClearInformationBoxes(TextBox dateOfSale, TextBox dateOfPayment, RichTextBox remarksTextBox,
		FlowLayoutPanel flowPanel, List<SoldProductsServicesItems> allProducts)
	{
		dateOfSale.Clear();
		dateOfPayment.Clear();
		remarksTextBox.Clear();
		flowPanel.Controls.Clear();
		allProducts.Clear();
	}

	public async Task PopulateInvoicesTable(DataGridView table)
	{
		table.DataSource = null;
		string key = $"Invoice:{_sessionService.CurrentAccount.Id}";

		var cachedList = _cacheService.Get<Invoice>(key);

		if (cachedList != null)
		{
			table.DataSource = cachedList;
		}
		else
		{
			var listFromDb = await _invoiceRepository.GetAllInvoicesOfAnAccount(_sessionService.CurrentAccount.Id);

			_cacheService.SetList<Invoice>(listFromDb.ToHashSet(), key, TimeSpan.FromHours(1));

			table.DataSource = listFromDb;
		}
	}

	public async Task PopulateClientsComboBox(ComboBox clientsComboBox)
	{
		int currId = _sessionService.CurrentAccount.Id;
		string key = $"client:{currId}";

		HashSet<Client> cachedList = _cacheService.Get<HashSet<Client>>(key);

		if (cachedList != null)
		{
			clientsComboBox.Items.AddRange(cachedList.ToArray());
		}
        else
        {
            var listFromDb = await _clientRepository.GetAllClients(currId.ToString());

			_cacheService.SetList<Client>(listFromDb.ToHashSet(), key, TimeSpan.FromHours(1));

			clientsComboBox.Items.AddRange(listFromDb.ToArray());
		}
	}

	public bool ValidateFlowItems(FlowLayoutPanel panel)
	{
		foreach (SoldProductsServicesItems item in panel.Controls)
		{
			if (!item.ValidateItem())
			{
				return false;
			}
		}
		return true;
	}

	public bool ValidateInvoiceForm111(TextBox dateOfSale, TextBox dateOfPayment, List<SoldProductsServicesItems> items)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int counter = 1;
		bool isValid = true;

		string patternEng = "^[0-9]{2}\\/[0-9]{2}\\/[0-9]{4}$";
		string patternPl = "^[0-9]{2}\\.[0-9]{2}\\.[0-9]{4}$";
		Language lang = LanguageHelper.GetLanguage;

		if (lang == Language.Polish_Pl)
		{
			stringBuilder.Append("Wystąpił problem z twoim formularzem:\n");
		}
		else if (lang == Language.English_Us)
		{
			stringBuilder.Append("There was  aproblem with your form:\n");
		}

		if (string.IsNullOrEmpty(dateOfSale.Text))
		{
			if (lang == Language.Polish_Pl)
			{
				stringBuilder.Append($"{counter}. Wprowadź datę sprzedaży.\n");
			}
			else if (lang == Language.English_Us)
			{
				stringBuilder.Append($"{counter}. Provide a date of sale.\n");
			}
			isValid = false;
			counter++;
		}
		else if (!Regex.Match(dateOfSale.Text, patternEng).Success &&
					!Regex.Match(dateOfSale.Text, patternPl).Success)
		{
			if (lang == Language.Polish_Pl)
			{
				stringBuilder.Append($"{counter}. Wprowadź poprawną datę sprzedaży.\n");
			}
			else if (lang == Language.English_Us)
			{
				stringBuilder.Append($"{counter}. Provide a valid date of sale.\n");
			}
			counter++;
			isValid = false;
		}

		if (string.IsNullOrEmpty(dateOfPayment.Text))
		{
			if (lang == Language.Polish_Pl)
			{
				stringBuilder.Append($"{counter}. Wprowadź datę płatności.\n");
			}
			else if (lang == Language.English_Us)
			{
				stringBuilder.Append($"{counter}. Provide a date of payment.\n");
			}
			counter++;
			isValid = false;
		}
		else if (!Regex.Match(dateOfPayment.Text, patternEng).Success &&
					!Regex.Match(dateOfPayment.Text, patternPl).Success)
		{
			if (lang == Language.Polish_Pl)
			{
				stringBuilder.Append($"{counter}. Wprowadź poprawną datę płatności.\n");
			}
			else if (lang == Language.English_Us)
			{
				stringBuilder.Append($"{counter}. Provide a valid date of payment.\n");
			}
			counter++;
			isValid = false;
		}

		if (items.Count < 1)
		{
			if (lang == Language.Polish_Pl)
			{
				stringBuilder.Append($"{counter}. Wprowadź przynajmniej jeden produkt lub usługę.\n");
			}
			else if (lang == Language.English_Us)
			{
				stringBuilder.Append($"{counter}. Provide at least one service or product.\n");
			}

			isValid = false;
		}

		if (!isValid)
		{
			if (lang == Language.Polish_Pl)
			{
				MessageBox.Show(stringBuilder.ToString(), "Faktura nieprawidłowa");
			}
			else if (lang == Language.English_Us)
			{
				MessageBox.Show(stringBuilder.ToString(), "Invalid invoice");
			}
		}
		return isValid;
	}

	public bool ValidateInvoiceForm(string dateOfSale, string dateOfPayment, List<SoldProductsServicesItems> items)
	{
		FluentErrors _errors = new FluentErrors();
		StringBuilder errors = new StringBuilder(_errorMessages.InvoiceErrorHeader);

		_errors.Parameter(dateOfSale)
			.IsNullOrEmptyString(_errorMessages.DateOfSaleMissingError)
			.SatisfyRegex(RegexConstants.VALID_DATE, _errorMessages.DateOfSaleInvalidError);

		_errors.Parameter(dateOfPayment)
			.IsNullOrEmptyString(_errorMessages.DateOfPayementMissingError)
			.SatisfyRegex(RegexConstants.VALID_DATE, _errorMessages.DateOfPaymentInvalid);

		_errors
			.SatysfiesCondition(() => items.Count != 0, _errorMessages.NoProductsAddedError);

		if (!_errors.IsValid)
		{
			_errors.GetErrors().ForEach(message => errors.AppendLine(message));
			log.InfoFormat("Validation failed:\n{0}",errors.ToString());

			_messageService.ShowError(errors.ToString());
			return false;
		}

		log.InfoFormat("Validation of the invoice successful! ");
		return true;
	}
}
